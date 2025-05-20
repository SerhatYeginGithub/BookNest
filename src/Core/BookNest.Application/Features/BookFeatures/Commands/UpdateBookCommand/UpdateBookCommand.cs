using BookNest.Application.Dtos;
using BookNest.Domain.Enums;
using MediatR;

namespace BookNest.Application.Features.BookFeatures.Commands.UpdateBookCommand;

public sealed record UpdateBookCommand : IRequest<MessageResponse>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }
    public BookStatus Status { get; set; }
    public Guid AppUserId { get; set; }
}
