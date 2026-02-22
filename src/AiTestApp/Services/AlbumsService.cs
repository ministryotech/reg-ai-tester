using AiTestApp.Repositories;
using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Services;

#region | Interface |

/// <summary>
/// Interface for a service that manages album operations.
/// </summary>
public interface IAlbumsService
{
    /// <summary>
    /// Retrieves a random album view model, optionally filtered by genre.
    /// </summary>
    /// <param name="genre">The genre to filter by, or null for any genre.</param>
    /// <param name="lastTitle">The title of the last album shown.</param>
    /// <returns>A randomly selected album view model.</returns>
    AlbumViewModel GetRandom(string? genre = null, string? lastTitle = null);
}

#endregion

/// <summary>
/// Service that manages album operations.
/// </summary>
public class AlbumsService(IAlbumsRepository repository, IAlbumModelBuilder builder) : IAlbumsService
{
    /// <inheritdoc />
    public AlbumViewModel GetRandom(string? genre = null, string? lastTitle = null)
    {
        var albums = repository.GetAll();
        if (!string.IsNullOrWhiteSpace(genre))
            albums = albums.Where(a => a.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));

        var albumList = albums.ToList();
        if (albumList.Count == 0)
            throw new InvalidOperationException("No albums found.");

        var pool = string.IsNullOrWhiteSpace(lastTitle)
            ? albumList
            : albumList.Where(a => a.Title != lastTitle).ToList();

        if (pool.Count == 0)
            pool = albumList;

        var random = new Random();
        return builder.Build(pool[random.Next(pool.Count)]);
    }
}
