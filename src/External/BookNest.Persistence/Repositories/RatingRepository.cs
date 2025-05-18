using BookNest.Application.Repositories;
using BookNest.Domain.Entities;
using BookNest.Persistence.Context;

namespace BookNest.Persistence.Repositories;

public sealed class RatingRepository : Repository<Rating>, IRatingRepository
{
    public RatingRepository(AppDbContext context) : base(context)
    {
    }
}
