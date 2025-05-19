using BookNest.Application.Services;
using BookNest.Domain.Dtos.Book;
using MediatR;

namespace BookNest.Application.Features.BookFeatures.Queries.GetBookByIdQuery;

internal class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDetailDto>
{
    private readonly IBookService _bookService;

    public GetBookByIdQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<BookDetailDto> Handle(GetBookByIdQuery request, CancellationToken cancellationToken) =>
        await _bookService.GetBookByIdAsync(request, cancellationToken);
}
