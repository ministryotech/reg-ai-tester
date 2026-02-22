using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories;

namespace AiTestApp.Services;

#region | Interface |

/// <summary>
/// Interface for a service that manages movie operations.
/// </summary>
public interface IMoviesService
{
    /// <summary>
    /// Retrieves a random movie view model, optionally excluding a specific movie title.
    /// </summary>
    /// <param name="lastTitle">The title of the last movie shown, to be excluded from the random selection.</param>
    /// <returns>A randomly selected movie view model.</returns>
    MovieViewModel GetRandomMovie(string? lastTitle = null);
}

#endregion

/// <summary>
/// Service that manages movie operations.
/// </summary>
/// <param name="moviesRepository">The repository for movie data.</param>
/// <param name="movieModelBuilder">The builder for movie view models.</param>
public class MoviesService(IMoviesRepository moviesRepository, IMovieModelBuilder movieModelBuilder) : IMoviesService
{
    /// <inheritdoc />
    public MovieViewModel GetRandomMovie(string? lastTitle = null)
    {
        var movies = moviesRepository.GetAllMovies().ToList();

        if (movies.Count == 0)
        {
            throw new InvalidOperationException("No movies found in the repository.");
        }

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
        return movieModelBuilder.Build(movie);
    }
}
