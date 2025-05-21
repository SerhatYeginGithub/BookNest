using BookNest.Application.Dtos;
using BookNest.Application.Services;
using MediatR;

namespace BookNest.Application.Features.NoteFeatures.Commands.DeleteNoteCommand;

public sealed class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, MessageResponse>
{
    private readonly INoteService _noteService;

    public DeleteNoteCommandHandler(INoteService noteService)
    {
        _noteService = noteService;
    }

    public async Task<MessageResponse> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        await _noteService.SoftDeleteAsync(request, cancellationToken);
        return new("Note deleted successfully");
    }
}
