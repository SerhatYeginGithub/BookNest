using BookNest.Application.Dtos;
using MediatR;

namespace BookNest.Application.Features.NoteFeatures.Commands.DeleteNoteCommand;

public sealed record DeleteNoteCommand(Guid Id) : IRequest<MessageResponse>;
