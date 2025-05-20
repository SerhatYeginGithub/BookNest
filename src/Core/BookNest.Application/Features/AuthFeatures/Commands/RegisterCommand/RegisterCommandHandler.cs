using BookNest.Application.Dtos;
using BookNest.Application.Services;
using MediatR;

namespace BookNest.Application.Features.AuthFeatures.Commands.RegisterCommand;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, MessageResponse>
{
    private readonly IAuthService _authService;

    public RegisterCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<MessageResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _authService.RegisterAsync(request, cancellationToken);
        return new($"Verification Code sent to {request.Email}");
    }
}
