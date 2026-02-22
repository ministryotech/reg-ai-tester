using Microsoft.Extensions.DependencyInjection;
using AiTestApp.Services;
using AiTestApp.ModelBuilders;

namespace AiTestApp.Config;

/// <summary>
/// Extension methods for configuring application-related services in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services) =>
        services.AddScoped<IMoviesService, MoviesService>()
                .AddScoped<IMovieModelBuilder, MovieModelBuilder>();
}
