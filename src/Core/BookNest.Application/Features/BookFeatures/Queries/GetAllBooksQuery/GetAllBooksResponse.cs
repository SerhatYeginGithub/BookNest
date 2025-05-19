using BookNest.Domain.Enums;

namespace BookNest.Application.Features.BookFeatures.Queries.GetAllBooksQuery;

public sealed record GetAllBooksResponse(Guid Id,string Title, string? Image, BookStatus Status, DateTime CreatedDate);