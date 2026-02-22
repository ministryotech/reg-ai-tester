using System.Text.Json;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Repositories;

#region | Interface |

/// <summary>
/// Interface for a repository that manages movie data.
/// </summary>
public interface IMoviesRepository
{
    /// <summary>
    /// Retrieves all available movies.
    /// </summary>
    /// <returns>An enumerable collection of all movies.</returns>
    IList<Movie> GetAllMovies();
}

#endregion

/// <summary>
/// A repository that provides access to movies from a JSON data source.
/// </summary>
/// <param name="jsonDataSource">The source of raw JSON movie data.</param>
public class MoviesRepository(IMoviesJsonDataSourceRepository jsonDataSource) : IMoviesRepository
{
    /// <inheritdoc />
    public IList<Movie> GetAllMovies() =>
        JsonSerializer.Deserialize<List<Movie>>(jsonDataSource.ReadRawJson()) ?? [];
}
