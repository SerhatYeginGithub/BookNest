using BookNest.Application.Dtos;
using BookNest.Application.Services;
using MediatR;

namespace BookNest.Application.Features.BookFeatures.Commands.CreateBookCommand;

public sealed class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, MessageResponse>
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
