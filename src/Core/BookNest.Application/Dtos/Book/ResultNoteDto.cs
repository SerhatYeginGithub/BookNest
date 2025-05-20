namespace BookNest.Application.Dtos.Book;

public sealed record ResultNoteDto
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid BookId { get; set; }
    public DateTime CreatedDate { get; set; }

}
