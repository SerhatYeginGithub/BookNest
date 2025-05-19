using AutoMapper;
using BookNest.Application.Features.BookFeatures.Commands.CreateBookCommand;
using BookNest.Application.Features.BookFeatures.Commands.UpdateBookCommand;
using BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;
using BookNest.Application.Features.BookFeatures.Queries.GetBookByIdQuery;
using BookNest.Application.Repositories;
using BookNest.Application.Services;
using BookNest.Application.UnitOfWorks;
using BookNest.Domain.Dtos.Book;
using BookNest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IList<GetAllBooksResponse>> GetAllBooksAsync(GetAllBooksQuery request, CancellationToken cancellationToken = default)
    {
        var books = await _bookRepository
         .Where(p => p.AppUserId == request.UserId)
         .ToListAsync(cancellationToken);

        var response = _mapper.Map<List<GetAllBooksResponse>>(books);

        return response;
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

