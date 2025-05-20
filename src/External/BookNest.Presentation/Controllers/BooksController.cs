using BookNest.Application.Features.BookFeatures.Commands.CreateBookCommand;
using BookNest.Application.Features.BookFeatures.Commands.UpdateBookCommand;
using BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;
using BookNest.Application.Features.BookFeatures.Queries.GetBookByIdQuery;
using BookNest.Domain.Enums;
using BookNest.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Presentation.Controllers;

public sealed class BooksController : ApiController
{
    public BooksController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> AddBook(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[Action]")]
    public async Task<IActionResult> UpdateBook(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> GetAllBooks(Guid userId, int page, int pageSize, BookStatus? bookStatus,  CancellationToken cancellationToken)
    {
        var request = new GetAllBooksQuery(userId, bookStatus, page, pageSize);

        var response = await _mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("[Action]")]
    public async Task<IActionResult> GetBookById(Guid bookId, CancellationToken cancellationToken)
    {
        var request = new GetBookByIdQuery(bookId);
        var response = await _mediator.Send(request,cancellationToken);

        return Ok(response);
    }

}
