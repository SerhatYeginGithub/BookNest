using BookNest.Domain.Abstractions;
using BookNest.Domain.Enums;

namespace BookNest.Domain.Entities;

public sealed class Book : Entity
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }
    public BookStatus Status { get; set; }

    public Guid AppUserId { get; set; }
    public AppUser AppUser { get; set; }

    public Note? Note { get; set; }
    public Rating? Rating { get; set; }
}
