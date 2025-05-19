using MediatR;

namespace BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;


public sealed record GetAllBooksQuery(Guid UserId) : IRequest<IList<GetAllBooksResponse>>;
