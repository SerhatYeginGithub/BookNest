using BookNest.Domain.Entities;
using BookNest.Domain.Enums;

namespace BookNest.Application.Dtos.Book;

public sealed record BookDetailDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }
    public BookStatus Status { get; set; }
    public ResultNoteDto? Note { get; set; }
    public ResultRatingDto? Rating { get; set; }
}
