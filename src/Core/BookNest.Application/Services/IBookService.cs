using BookNest.Application.Dtos.Book;
using BookNest.Application.Dtos.Pagination;
using BookNest.Application.Features.BookFeatures.Commands.CreateBookCommand;
using BookNest.Application.Features.BookFeatures.Commands.UpdateBookCommand;
using BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;
using BookNest.Application.Features.BookFeatures.Queries.GetBookByIdQuery;

namespace BookNest.Application.Services;

public interface IBookService
{
    Task CreateAsync(CreateBookCommand request, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateBookCommand request, CancellationToken cancellationToken = default);
    Task<PaginatedBooksResponse<GetAllBooksResponse>> GetAllBooksAsync(GetAllBooksQuery request, CancellationToken cancellationToken = default);
    Task<BookDetailDto> GetBookByIdAsync(GetBookByIdQuery request, CancellationToken cancellationToken = default);
}
