namespace BookNest.Application.UnitOfWorks;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}
