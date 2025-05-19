using FluentValidation;

namespace BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;

internal sealed class GetAllBooksQueryValidator : AbstractValidator<GetAllBooksQuery>
{
    public GetAllBooksQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Id is required.");
    }
}
