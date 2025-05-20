using AutoMapper;
using BookNest.Application.Abstractions;
using BookNest.Application.Dtos;
using BookNest.Application.Features.AuthFeatures.Commands.LoginCommand;
using BookNest.Application.Features.AuthFeatures.Commands.RegisterCommand;
using BookNest.Application.Features.AuthFeatures.Commands.VerifyCodeCommand;
using BookNest.Application.Services;
using BookNest.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace BookNest.Persistence.Services;

public sealed class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IMailSender _mailSender;
    private readonly IMemoryCache _cache;
    private readonly IJwtProvider _jwtProvider;

    public AuthService(UserManager<AppUser> userManager, IMapper mapper, IMailSender mailSender, IMemoryCache cache, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _mapper = mapper;
        _mailSender = mailSender;
        _cache = cache;
        _jwtProvider = jwtProvider;
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
        if (result)
        {
            LoginResponse response = await _jwtProvider.CreateTokenAsync(user);
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
                _cache.Remove(registerRequest.Email);

                AppUser user = _mapper.Map<AppUser>(registerRequest);

                IdentityResult result = await _userManager.CreateAsync(user, registerRequest.Password);

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
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
