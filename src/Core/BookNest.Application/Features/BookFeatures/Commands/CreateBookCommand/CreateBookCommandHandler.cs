using BookNest.Application.Services;
using BookNest.Domain.Dtos;
using MediatR;

namespace BookNest.Application.Features.BookFeatures.Commands.CreateBookCommand;

internal sealed class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, MessageResponse>
{
    private readonly IBookService _bookService;

    public CreateBookCommandHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<MessageResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        await _bookService.CreateAsync(request, cancellationToken);
        return new("Book created succesfully.");
    }
}
