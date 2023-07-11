using Microsoft.EntityFrameworkCore;
using Travel.API.Contracts;
using Travel.API.Entities.Contexts;
using Travel.API.Middleware;
using Travel.API.Repositories;

namespace Travel.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterDb(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<TravelPlannerDbContext>(
            opt => opt.UseNpgsql(configuration.GetConnectionString("Db"))
        );

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IDestinationRepository, DestinationRepository>();

        return services;
    }

    public static IServiceCollection AddMiddlewares(this IServiceCollection services)
    {
        services.AddSingleton<ErrorHandlingMiddleware>();

        return services;
    }
}
