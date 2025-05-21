using BookNest.Application.Dtos;
using BookNest.Application.Services;
using MediatR;

namespace BookNest.Application.Features.NoteFeatures.Commands.CreateNoteCommand;

public sealed class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, MessageResponse>
{
    private readonly INoteService _noteService;

    public CreateNoteCommandHandler(INoteService noteService)
    {
        _noteService = noteService;
    }

    public async Task<MessageResponse> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        await _noteService.CreateAsync(request, cancellationToken);

        return new("Note created successfully.");
    }
}
