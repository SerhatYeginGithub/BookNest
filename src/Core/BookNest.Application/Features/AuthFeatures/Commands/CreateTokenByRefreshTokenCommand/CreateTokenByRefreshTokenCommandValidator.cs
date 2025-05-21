using FluentValidation;

namespace BookNest.Application.Features.AuthFeatures.Commands.CreateTokenByRefreshTokenCommand;

public sealed class CreateTokenByRefreshTokenCommandValidator : AbstractValidator<CreateTokenByRefreshTokenCommand>
{
    public CreateTokenByRefreshTokenCommandValidator()
    {
    }
}
