using BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;

namespace BookNest.Application.Dtos.Pagination;

public sealed record PaginatedBooksResponse<T> where T : class
{

    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public IList<T> Items { get; set; } = new List<T>();
}
