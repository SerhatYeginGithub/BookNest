using Microsoft.Extensions.DependencyInjection;

namespace BookNest.Application;

public static class Registration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));
    }
}