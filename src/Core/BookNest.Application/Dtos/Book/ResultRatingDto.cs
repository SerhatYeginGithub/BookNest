namespace BookNest.Application.Dtos.Book;

public sealed record ResultRatingDto
{
    public Guid Id { get; set; }
    public int Value { get; set; }
    public Guid BookId { get; set; }
    public DateTime CreatedDate { get; set; }
}