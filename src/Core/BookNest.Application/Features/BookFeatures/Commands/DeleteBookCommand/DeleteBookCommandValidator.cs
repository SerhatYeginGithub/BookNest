using FluentValidation;

namespace BookNest.Application.Features.BookFeatures.Commands.DeleteBookCommand;

public sealed class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty().WithMessage("Id is required.")
           .NotNull().WithMessage("Id is required");
    }
}
