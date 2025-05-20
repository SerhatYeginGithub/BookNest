using BookNest.Application.Dtos.Pagination;
using BookNest.Domain.Enums;
using MediatR;

namespace BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;


public sealed record GetAllBooksQuery(Guid UserId, BookStatus? Status, int Page = 1, int PageSize = 10) : IRequest<PaginatedBooksResponse<GetAllBooksResponse>>;
