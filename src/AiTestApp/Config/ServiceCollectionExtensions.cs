using Microsoft.Extensions.DependencyInjection;
using AiTestApp.Services;
using AiTestApp.ModelBuilders;

namespace AiTestApp.Config;

/// <summary>
/// Extension methods for configuring application-related services in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds application-related dependencies to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<IMoviesService, MoviesService>();
        services.AddScoped<IMovieModelBuilder, MovieModelBuilder>();

        return services;
    }
}
