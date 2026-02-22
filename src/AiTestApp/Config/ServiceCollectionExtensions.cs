using Microsoft.Extensions.DependencyInjection;
using AiTestApp.Services;
using AiTestApp.ModelBuilders;

namespace AiTestApp.Config;

/// <summary>
/// Extension methods for configuring application-related services in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    extension (IServiceCollection services)
    {
        /// <summary>
        /// Adds application-related dependencies to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public IServiceCollection AddApplicationDependencies() =>
            services.AddScoped<IMoviesService, MoviesService>()
                    .AddScoped<IMovieModelBuilder, MovieModelBuilder>()
                    .AddScoped<ITvShowModelBuilder, TvShowModelBuilder>()
                    .AddScoped<IBookModelBuilder, BookModelBuilder>()
                    .AddScoped<IAlbumModelBuilder, AlbumModelBuilder>()
                    .AddScoped<ITvShowsService, TvShowsService>()
                    .AddScoped<IBooksService, BooksService>()
                    .AddScoped<IAlbumsService, AlbumsService>()
                    .AddScoped<IDiceService, DiceService>();
    }
}
