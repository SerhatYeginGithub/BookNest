using BookNest.Application.Dtos;
using BookNest.Application.Services;
using MediatR;

namespace BookNest.Application.Features.BookFeatures.Commands.DeleteBookCommand;

public sealed class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, MessageResponse>
{
    private readonly IBookService _bookService;

    public DeleteBookCommandHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<MessageResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        await _bookService.SoftDeleteAsync(request, cancellationToken);
        return new("Book deleted successfully.");
    }
}
