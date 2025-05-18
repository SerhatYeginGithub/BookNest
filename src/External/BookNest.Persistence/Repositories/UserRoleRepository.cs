using BookNest.Application.Repositories;
using BookNest.Domain.Entities;
using BookNest.Persistence.Context;

namespace BookNest.Persistence.Repositories;

public sealed class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext context) : base(context)
    {
    }
}
