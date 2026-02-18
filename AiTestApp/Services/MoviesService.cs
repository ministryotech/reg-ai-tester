using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories;

namespace AiTestApp.Services;

/// <summary>
/// Service that manages movie operations.
/// </summary>
public class MoviesService : IMoviesService
{
    private readonly IMoviesRepository _moviesRepository;
    private readonly IMovieModelBuilder _movieModelBuilder;

    public MoviesService(IMoviesRepository moviesRepository, IMovieModelBuilder movieModelBuilder)
    {
        _moviesRepository = moviesRepository;
        _movieModelBuilder = movieModelBuilder;
    }

    /// <inheritdoc />
    public MovieViewModel GetRandomMovie(string? lastTitle = null)
    {
        var movies = _moviesRepository.GetAllMovies().ToList();
        var random = new Random();
        var pool = string.IsNullOrWhiteSpace(lastTitle)
            ? movies
            : movies.Where(m => m.Title != lastTitle).ToList();

        // Fallback if the pool is empty (e.g., only one movie in movies)
        if (pool.Count == 0)
        {
            pool = movies;
        }

        var movie = pool[random.Next(pool.Count)];
        return _movieModelBuilder.Build(movie);
    }
}
