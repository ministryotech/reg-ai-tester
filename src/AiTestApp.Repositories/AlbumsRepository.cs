using System.Text.Json;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Repositories;

#region | Interface |

/// <summary>
/// Interface for a repository that manages album data.
/// </summary>
public interface IAlbumsRepository
{
    /// <summary>
    /// Retrieves all available albums.
    /// </summary>
    /// <returns>An enumerable collection of all albums.</returns>
    IEnumerable<Album> GetAll();
}

#endregion

/// <summary>
/// A repository that provides access to albums from a JSON data source.
/// </summary>
/// <param name="jsonDataSource">The source of raw JSON album data.</param>
public class AlbumsRepository(IAlbumsJsonDataSourceRepository jsonDataSource) : IAlbumsRepository
{
    /// <inheritdoc />
    public IEnumerable<Album> GetAll() =>
        JsonSerializer.Deserialize<List<Album>>(jsonDataSource.ReadRawJson()) ?? [];
}
