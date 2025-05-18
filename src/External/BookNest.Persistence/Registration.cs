using Microsoft.EntityFrameworkCore;
using BookNest.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookNest.Application.Repositories;
using BookNest.Persistence.Repositories;
using BookNest.Application.UnitOfWorks;

namespace BookNest.Persistence;

public static class Registration
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("SqlServer");
        services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(connectionString));

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddScoped<IRatingRepository, RatingRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
