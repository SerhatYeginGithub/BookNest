using FluentValidation;

namespace BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;

public sealed class GetAllBooksQueryValidator : AbstractValidator<GetAllBooksQuery>
{
    public GetAllBooksQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Page)
            .NotNull().WithMessage("Page is required.")
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page must be at least 1.");
            

        RuleFor(x => x.PageSize)
            .NotNull().WithMessage("PageSize is required.")
            .InclusiveBetween(1, 100)
            .WithMessage("PageSize must be between 1 and 100.");

        RuleFor(x => x.Status)
            .IsInEnum()
            .WithMessage("Status value is invalid.");
    }
}
