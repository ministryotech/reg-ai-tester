using Microsoft.Extensions.DependencyInjection;

namespace AiTestApp.Repositories.Config;

/// <summary>
/// Extension methods for configuring repository-related services in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services) =>
        services.AddScoped<IMoviesRepository, MoviesRepository>();
}
