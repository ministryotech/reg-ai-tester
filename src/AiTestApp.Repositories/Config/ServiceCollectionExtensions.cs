using Microsoft.Extensions.DependencyInjection;

namespace AiTestApp.Repositories.Config;

/// <summary>
/// Extension methods for configuring repository-related services in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds repository-related dependencies to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
    {
        services.AddScoped<IMoviesRepository, MoviesRepository>();

        return services;
    }
}
