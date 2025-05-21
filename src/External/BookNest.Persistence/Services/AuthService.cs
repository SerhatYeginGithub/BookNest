using AutoMapper;
using BookNest.Application.Abstractions;
using BookNest.Application.Dtos;
using BookNest.Application.Features.AuthFeatures.Commands.CreateTokenByRefreshTokenCommand;
using BookNest.Application.Features.AuthFeatures.Commands.LoginCommand;
using BookNest.Application.Features.AuthFeatures.Commands.RegisterCommand;
using BookNest.Application.Features.AuthFeatures.Commands.VerifyCodeCommand;
using BookNest.Application.Services;
using BookNest.Domain.Constants;
using BookNest.Domain.Entities;
using BookNest.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace BookNest.Persistence.Services;

public sealed class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly IMapper _mapper;
    private readonly IMailSender _mailSender;
    private readonly IMemoryCache _cache;
    private readonly IJwtProvider _jwtProvider;

    public AuthService(UserManager<AppUser> userManager, IMapper mapper, IMailSender mailSender, IMemoryCache cache, IJwtProvider jwtProvider, RoleManager<AppRole> roleManager, AppDbContext context)
    {
        _userManager = userManager;
        _mapper = mapper;
        _mailSender = mailSender;
        _cache = cache;
        _jwtProvider = jwtProvider;
        _roleManager = roleManager;
        _context = context;
    }

    public async Task<LoginResponse> CreateTokenByRefreshTokenAsync(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken = default)
    {
        AppUser user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null) 
            throw new Exception("User not found!");

        if (user.RefreshToken != request.RefreshToken)
            throw new Exception("Invalid refresh token");

        if (user.RefreshTokenExpires < DateTime.Now)
            throw new Exception("Invalid Refresh Token");
        var roles = await _userManager.GetRolesAsync(user);
        if (roles == null || !roles.Any())
            throw new InvalidOperationException("User does not have any assigned roles.");

        var role = roles.First();
        LoginResponse response = await _jwtProvider.CreateTokenAsync(user, role);
        return response;
    }

    public async Task<LoginResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken = default)
    {
        AppUser? user =
           await _userManager.Users
           .Where(
               p => p.UserName == request.UserNameOrEmail
                 || p.Email == request.UserNameOrEmail)
           .FirstOrDefaultAsync(cancellationToken);

        if (user == null) throw new Exception("User can not found");

        var result = await _userManager.CheckPasswordAsync(user, request.Password);
        var roles = await _userManager.GetRolesAsync(user);
        var role = roles.FirstOrDefault();
        if (result && role is not null)
        {
            LoginResponse response = await _jwtProvider.CreateTokenAsync(user, role);
            return response;
        }

        throw new Exception("User name or password is wrong.");
    }

    public async Task RegisterAsync(RegisterCommand request, CancellationToken cancellationToken = default)
    {
        var isEmailExist = await IsEmailExistAsync(request.Email);
        var isUserNameExist = await IsUserNameExistAsync(request.Username);
        if (isEmailExist)
            throw new Exception("This email is already taken.");

        if (isUserNameExist)
            throw new Exception("This username is already taken.");

        var code = new Random().Next(100000, 999999).ToString();

        await _mailSender.SendEmailAsync(request.Email, request.Name, code);

        _cache.Set(request.Email, (request, code), TimeSpan.FromMinutes(2));

    }

    public async Task VerifyCodeAsync(VerifyCodeCommand request, CancellationToken cancellationToken = default)
    {
        if (_cache.TryGetValue<(RegisterCommand, string)>(request.Email, out var cachedData))
        {
            var (registerRequest, storedCode) = cachedData;

            if (storedCode == request.Code)
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                   
                    AppUser user = _mapper.Map<AppUser>(registerRequest);

                    IdentityResult result = await _userManager.CreateAsync(user, registerRequest.Password);

                    if (!result.Succeeded)
                    {
                        await transaction.RollbackAsync();
                        throw new Exception(result.Errors.First().Description);
                    }

                    var userRoleResult = await _userManager.AddToRoleAsync(user, Role.User);
                    if (!userRoleResult.Succeeded)
                    {
                        await transaction.RollbackAsync();
                        throw new Exception(userRoleResult.Errors.First().Description);
                    }
                    await transaction.CommitAsync();

                    _cache.Remove(registerRequest.Email);

                } catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            else
            {
                throw new Exception("Doğrulama kodu hatalı.");
            }
        }
        else
        {
            throw new Exception("Doğrulama kodu süresi dolmuş veya geçersiz.");
        }
    }

    private async Task<bool> IsEmailExistAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user != null;
    }
    private async Task<bool> IsUserNameExistAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        return user != null;
    }
}
