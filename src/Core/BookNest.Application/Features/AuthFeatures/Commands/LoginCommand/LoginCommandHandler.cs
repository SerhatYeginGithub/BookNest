using BookNest.Application.Services;
using BookNest.Domain.Dtos;
using MediatR;

namespace BookNest.Application.Features.AuthFeatures.Commands.LoginCommand;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginResponse response = await _authService.LoginAsync(request, cancellationToken);

        return response;
    }
}
