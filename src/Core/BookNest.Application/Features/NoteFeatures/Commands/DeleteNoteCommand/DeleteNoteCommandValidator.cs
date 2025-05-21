using FluentValidation;

namespace BookNest.Application.Features.NoteFeatures.Commands.DeleteNoteCommand;

public sealed class DeleteNoteCommandValidator : AbstractValidator<DeleteNoteCommand>
{
    public DeleteNoteCommandValidator()
    {
        RuleFor(x => x.Id)
         .NotEmpty().WithMessage("Id is required.")
         .NotNull().WithMessage("Id is required.");
    }
}
