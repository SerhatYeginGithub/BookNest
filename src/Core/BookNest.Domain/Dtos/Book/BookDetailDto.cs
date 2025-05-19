using BookNest.Domain.Entities;
using BookNest.Domain.Enums;

namespace BookNest.Domain.Dtos.Book;

public sealed record BookDetailDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }
    public BookStatus Status { get; set; }
    public Note? Note { get; set; }
    public Rating? Rating { get; set; }
}
