using BookNest.Application.Dtos;
using BookNest.Application.Services;
using MediatR;

namespace BookNest.Application.Features.BookFeatures.Commands.UpdateBookCommand;

public sealed class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, MessageResponse>
{
    private readonly IBookService _bookService;

    public UpdateBookCommandHandler(IBookService bookService)
    {
        _bookService = bookService;
    }

    public async Task<MessageResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        await _bookService.UpdateAsync(request, cancellationToken);
        return new("Book updated successfully.");
    }
}
