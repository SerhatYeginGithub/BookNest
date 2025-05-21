using FluentValidation;

namespace BookNest.Application.Features.NoteFeatures.Commands.CreateNoteCommand;

public sealed class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
{
    public CreateNoteCommandValidator()
    {
        RuleFor(x => x.BookId)
         .NotEmpty().WithMessage("BookId is required.")
         .NotNull().WithMessage("BookId is required.");

        RuleFor(x => x.Content)
        .NotEmpty().WithMessage("Note content cannot be empty.")
        .MinimumLength(30).WithMessage("Note content must be 30 characters")
        .MaximumLength(1000).WithMessage("Note content must be less than 1000 characters.");
    }
}
