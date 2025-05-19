using FluentValidation;

namespace BookNest.Application.Features.AuthFeatures.Commands.RegisterCommand;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(p => p.Username)
        .NotEmpty().WithMessage("Username is required.")
        .NotNull().WithMessage("Username cannot be null.")
        .MinimumLength(3).WithMessage("Username must be at least 3 characters long.");

        RuleFor(p => p.Name)
        .NotEmpty().WithMessage("First name is required.")
        .NotNull().WithMessage("First name cannot be null.")
        .MinimumLength(3).WithMessage("First name must be at least 3 characters long.");

        RuleFor(p => p.Lastname)
        .NotEmpty().WithMessage("Last name is required.")
        .NotNull().WithMessage("Last name cannot be null.")
        .MinimumLength(3).WithMessage("Last name must be at least 3 characters long.");

        RuleFor(p => p.Email)
        .NotEmpty().WithMessage("Email is required.")
        .NotNull().WithMessage("Email cannot be null.")
        .MinimumLength(3).WithMessage("Email must be at least 3 characters long.")
        .EmailAddress().WithMessage("Please enter a valid email address.");

        RuleFor(p => p.Password)
        .NotEmpty().WithMessage("Password is required.")
        .NotNull().WithMessage("Password cannot be null.")
        .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
        .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
        .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
        .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
        .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
    }
}
