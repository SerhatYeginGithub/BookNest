using BookNest.Application.Dtos.Pagination;
using BookNest.Application.Services;
using MediatR;

namespace BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;

public sealed class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, PaginatedBooksResponse<GetAllBooksResponse>>
{
    private readonly IBookService _bookService;

    public GetAllBooksQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<PaginatedBooksResponse<GetAllBooksResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken) =>
        await _bookService.GetAllBooksAsync(request, cancellationToken);
}
