using FluentValidation;

namespace BookNest.Application.Features.BookFeatures.Commands.CreateBookCommand;

internal class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Title)
        .NotEmpty().WithMessage("Title cannot be empty.")
        .NotNull().WithMessage("Title is required.")
        .MinimumLength(2).WithMessage("Title must be at least 2 characters.");

      
        RuleFor(x => x.Author)
        .NotEmpty().WithMessage("Author cannot be empty.")
        .NotNull().WithMessage("Author is required.")
        .MinimumLength(2).WithMessage("Author must be at least 2 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description cannot be empty.")
            .NotNull().WithMessage("Description is required.")
            .MinimumLength(10).WithMessage("Description must be at least 10 characters.")
            .MaximumLength(500).WithMessage("Desciption must be max 500 characters");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Status value is invalid.");

        RuleFor(x => x.AppUserId)
            .NotEmpty().WithMessage("User ID is required.");
    }
}
