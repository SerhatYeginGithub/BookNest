using BookNest.Application.Dtos.Book;
using MediatR;

namespace BookNest.Application.Features.BookFeatures.Queries.GetBookByIdQuery;

public sealed record GetBookByIdQuery(Guid BookId) : IRequest<BookDetailDto>;

