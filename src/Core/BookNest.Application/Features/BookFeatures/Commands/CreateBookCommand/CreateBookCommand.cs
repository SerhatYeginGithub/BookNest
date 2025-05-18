using BookNest.Domain.Entities;
using BookNest.Domain.Enums;

namespace BookNest.Application.Features.BookFeatures.Commands.CreateBookCommand;

public sealed record CreateBookCommand
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }
    public BookStatus Status { get; set; }

    public Guid AppUserId { get; set; }
}
