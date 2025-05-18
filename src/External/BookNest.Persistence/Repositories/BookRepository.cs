using BookNest.Application.Repositories;
using BookNest.Domain.Entities;
using BookNest.Persistence.Context;

namespace BookNest.Persistence.Repositories;

public sealed class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(AppDbContext context) : base(context)
    {
    }
}
