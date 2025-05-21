using BookNest.Application.Dtos;
using MediatR;

namespace BookNest.Application.Features.NoteFeatures.Commands.CreateNoteCommand;

public sealed record CreateNoteCommand(Guid BookId, string Content) : IRequest<MessageResponse>;
