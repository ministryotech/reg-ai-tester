using Microsoft.Extensions.DependencyInjection;

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
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public IServiceCollection AddRepositoryDependencies() =>
            services.AddScoped<IAlbumsRepository, AlbumsRepository>()
                    .AddSingleton<IAlbumsJsonDataSourceRepository, AlbumsJsonDataSourceRepository>()
                    .AddScoped<IBooksRepository, BooksRepository>()
                    .AddSingleton<IBooksJsonDataSourceRepository, BooksJsonDataSourceRepository>()
                    .AddScoped<IMoviesRepository, MoviesRepository>()
                    .AddSingleton<IMoviesJsonDataSourceRepository, MoviesJsonDataSourceRepository>()
                    .AddScoped<ITvShowsRepository, TvShowsRepository>()
                    .AddSingleton<ITvShowsJsonDataSourceRepository, TvShowsJsonDataSourceRepository>();
    }
}
