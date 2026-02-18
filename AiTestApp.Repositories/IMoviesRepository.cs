using AiTestApp.Repositories.Models;

namespace AiTestApp.Repositories;

/// <summary>
/// Interface for a repository that manages movie data.
/// </summary>
public interface IMoviesRepository
{
    /// <summary>
    /// Retrieves all available movies.
    /// </summary>
    /// <returns>An enumerable collection of all movies.</returns>
    IEnumerable<Movie> GetAllMovies();
}
