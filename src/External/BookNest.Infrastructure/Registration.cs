using BookNest.Application.Abstractions;
using BookNest.Application.Services;
using BookNest.Application.Dtos;
using BookNest.Infrastructure.Authentication;
using BookNest.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
namespace BookNest.Infrastructure;

public static class Registration
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        services.AddScoped<IMailSender, MailSender>();
        services.AddScoped<IJwtProvider, JwtProvider>();
    }
}
