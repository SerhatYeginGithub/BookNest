using BookNest.Application.Dtos;
using BookNest.Application.Services;
using MediatR;

namespace BookNest.Application.Features.AuthFeatures.Commands.CreateTokenByRefreshTokenCommand;

public sealed class CreateTokenByRefreshTokenCommandHandler : IRequestHandler<CreateTokenByRefreshTokenCommand, LoginResponse>
{
    private readonly IAuthService _authService;

    public CreateTokenByRefreshTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginResponse> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return await _authService.CreateTokenByRefreshTokenAsync(request, cancellationToken);
    }
}
