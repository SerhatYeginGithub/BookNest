using FluentValidation;

namespace BookNest.Application.Features.NoteFeatures.Queries.GetNoteByBookIdQuery;

public sealed class GetNoteByBookIdQueryValidator : AbstractValidator<GetNoteByBookIdQuery>
{
    public GetNoteByBookIdQueryValidator()
    {
        RuleFor(x => x.BookId)
         .NotEmpty().WithMessage("BookId is required.")
         .NotNull().WithMessage("BookId is required.");
    }
}
