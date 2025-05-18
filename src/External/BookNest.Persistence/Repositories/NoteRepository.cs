using BookNest.Application.Repositories;
using BookNest.Domain.Entities;
using BookNest.Persistence.Context;

namespace BookNest.Persistence.Repositories;

public sealed class NoteRepository : Repository<Note>, INoteRepository
{
    public NoteRepository(AppDbContext context) : base(context)
    {
    }
}
