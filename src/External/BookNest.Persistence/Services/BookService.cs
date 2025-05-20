using AutoMapper;
using BookNest.Application.Features.BookFeatures.Commands.CreateBookCommand;
using BookNest.Application.Features.BookFeatures.Commands.UpdateBookCommand;
using BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;
using BookNest.Application.Features.BookFeatures.Queries.GetBookByIdQuery;
using BookNest.Application.Repositories;
using BookNest.Application.Services;
using BookNest.Application.UnitOfWorks;
using BookNest.Application.Dtos.Book;
using BookNest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BookNest.Domain.Enums;
using BookNest.Application.Dtos.Pagination;

namespace BookNest.Persistence.Services;

public sealed class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public BookService(IBookRepository bookRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(CreateBookCommand request, CancellationToken cancellationToken = default)
    {
        await IsBookExist(request.AppUserId, request.Title);


        Book book = _mapper.Map<Book>(request);
        await _bookRepository.AddAsync(book, cancellationToken);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<PaginatedBooksResponse<GetAllBooksResponse>> GetAllBooksAsync(GetAllBooksQuery request, CancellationToken cancellationToken = default)
    {
        var query = _bookRepository.Where(p => p.AppUserId == request.UserId);

        if (request.Status.HasValue)
        {
            query = query.Where(p => p.Status == request.Status.Value);
        }

        var totalCount = await query.CountAsync(cancellationToken);

        var books = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);
      
        return new PaginatedBooksResponse<GetAllBooksResponse>
        {
            TotalCount = totalCount,
            PageNumber = request.Page,
            Items = _mapper.Map<List<GetAllBooksResponse>>(books)
        };

    }

    public async Task<BookDetailDto> GetBookByIdAsync(GetBookByIdQuery request, CancellationToken cancellationToken = default)
    {
        Book book = await _bookRepository.GetByExpressionAsync(b => b.Id == request.BookId);
        return _mapper.Map<BookDetailDto>(book);
    }

    public async Task UpdateAsync(UpdateBookCommand request, CancellationToken cancellationToken = default)
    {
        await IsBookExist(request.AppUserId, request.Title);

        Book book = _mapper.Map<Book>(request);
        _bookRepository.Update(book);
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task IsBookExist(Guid userId, string bookTitle)
    {
        var isExist = await _bookRepository.AnyAsync(b =>
          b.AppUserId == userId &&
          b.Title.ToLower().Trim() == bookTitle.ToLower().Trim());

        if (isExist)
            throw new Exception("Book is available.");
    }
}

