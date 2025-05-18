using BookNest.Domain.Abstractions;

namespace BookNest.Domain.Entities;

public sealed class Rating : Entity
{

    public int Value { get; set; }

    public Guid BookId { get; set; }
    public Book Book { get; set; }
}