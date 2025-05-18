using BookNest.Domain.Abstractions;

namespace BookNest.Domain.Entities;

public sealed class Note : Entity
{
    public string Content { get; set; }
    public Guid BookId { get; set; }
    public Book Book { get; set; }
}
