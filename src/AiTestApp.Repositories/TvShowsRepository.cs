using System.Text.Json;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Repositories;

#region | Interface |

/// <summary>
/// Interface for a repository that manages TV show data.
/// </summary>
public interface ITvShowsRepository
{
    /// <summary>
    /// Retrieves all available TV shows.
    /// </summary>
    /// <returns>An enumerable collection of all TV shows.</returns>
    IEnumerable<TvShow> GetAll();
}

#endregion

/// <summary>
/// A repository that provides access to TV shows from a JSON data source.
/// </summary>
/// <param name="jsonDataSource">The source of raw JSON TV show data.</param>
public class TvShowsRepository(ITvShowsJsonDataSourceRepository jsonDataSource) : ITvShowsRepository
{
    /// <inheritdoc />
    public IEnumerable<TvShow> GetAll() =>
        JsonSerializer.Deserialize<List<TvShow>>(jsonDataSource.ReadRawJson()) ?? [];
}
