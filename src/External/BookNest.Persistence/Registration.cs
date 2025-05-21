using Microsoft.EntityFrameworkCore;
using BookNest.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookNest.Application.Repositories;
using BookNest.Persistence.Repositories;
using BookNest.Application.UnitOfWorks;
using BookNest.Application.Services;
using BookNest.Persistence.Services;
namespace BookNest.Persistence;

public static class Registration
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("SqlServer");
        services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(connectionString));
        /// Repositories
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddScoped<IRatingRepository, RatingRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        /// Services 
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<INoteService, NoteService>();

        services.AddAutoMapper(typeof(AssemblyReference).Assembly);
    }
}
