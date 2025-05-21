using BookNest.Application.Dtos;
using BookNest.Application.Services;
using MediatR;

namespace BookNest.Application.Features.NoteFeatures.Commands.UpdateNoteCommand;

public sealed class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, MessageResponse>
{
    private readonly INoteService _noteService;

    public UpdateNoteCommandHandler(INoteService noteService)
    {
        _noteService = noteService;
    }

    public async Task<MessageResponse> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        await _noteService.UpdateAsync(request, cancellationToken);

        return new("Note updated successfully.");
    }
}
