using BookNest.Application.Dtos;
using MediatR;

namespace BookNest.Application.Features.NoteFeatures.Commands.UpdateNoteCommand;

public sealed record UpdateNoteCommand(Guid Id, Guid BookId, string Content) : IRequest<MessageResponse>;
