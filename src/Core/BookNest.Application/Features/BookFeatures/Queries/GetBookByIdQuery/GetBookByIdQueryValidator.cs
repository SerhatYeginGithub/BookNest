using FluentValidation;

namespace BookNest.Application.Features.BookFeatures.Queries.GetBookByIdQuery;

internal sealed class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
{
    public GetBookByIdQueryValidator()
    {
        RuleFor(x => x.BookId)
            .NotEmpty().WithMessage("Id is required.");
    }
}
