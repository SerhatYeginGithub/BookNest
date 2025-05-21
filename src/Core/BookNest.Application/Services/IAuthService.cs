using BookNest.Application.Features.AuthFeatures.Commands.LoginCommand;
using BookNest.Application.Features.AuthFeatures.Commands.RegisterCommand;
using BookNest.Application.Features.AuthFeatures.Commands.VerifyCodeCommand;
using BookNest.Application.Dtos;
using BookNest.Application.Features.AuthFeatures.Commands.CreateTokenByRefreshTokenCommand;

namespace BookNest.Application.Services;

public interface IAuthService
{
    Task RegisterAsync(RegisterCommand request, CancellationToken cancellationToken = default);
    Task<LoginResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken = default);
    Task VerifyCodeAsync(VerifyCodeCommand request, CancellationToken cancellationToken = default);
    Task<LoginResponse> CreateTokenByRefreshTokenAsync(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken = default);

}
