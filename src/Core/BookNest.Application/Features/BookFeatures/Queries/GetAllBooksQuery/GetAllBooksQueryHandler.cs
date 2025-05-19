using BookNest.Application.Services;
using MediatR;

namespace BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;

internal sealed class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, IList<GetAllBooksResponse>>
{
    private readonly IBookService _bookService;

    public GetAllBooksQueryHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<IList<GetAllBooksResponse>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken) =>
        await _bookService.GetAllBooksAsync(request, cancellationToken);
}
