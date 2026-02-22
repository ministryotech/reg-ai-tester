using Microsoft.Extensions.DependencyInjection;
using AiTestApp.Repositories.Contracts;
using AiTestApp.Repositories;

namespace AiTestApp.Repositories.Config;

/// <summary>
/// Extension methods for configuring repository-related services in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    extension (IServiceCollection services)
    {
        /// <summary>
        /// Adds repository-related dependencies to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="moviesFilePath">The path to the movies JSON file.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public IServiceCollection AddRepositoryDependencies(string moviesFilePath) =>
            services.AddSingleton<IJsonDataSourceRepository>(_ => new JsonDataSourceRepository(moviesFilePath))
                    .AddScoped<IMoviesRepository, MoviesRepository>();
    }
}
