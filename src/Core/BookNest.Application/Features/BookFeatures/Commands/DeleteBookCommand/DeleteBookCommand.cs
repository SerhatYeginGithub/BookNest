using BookNest.Application.Dtos;
using MediatR;

namespace BookNest.Application.Features.BookFeatures.Commands.DeleteBookCommand;

public sealed record DeleteBookCommand(Guid Id) : IRequest<MessageResponse>;
