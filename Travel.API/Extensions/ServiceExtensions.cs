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

    public static WebApplication MigrateDatabase(this WebApplication application)
    {
        using (var scope = application.Services.CreateScope())
        {
            using var dbContext =
                scope.ServiceProvider.GetRequiredService<TravelPlannerDbContext>();

            try
            {
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Failed applying DB migrations for DB {nameof(TravelPlannerDbContext)}",
                    ex
                );
            }
        }

        return application;
    }
}
