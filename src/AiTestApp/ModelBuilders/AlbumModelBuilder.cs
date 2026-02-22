using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.ModelBuilders;

#region | Interface |

/// <summary>
/// Interface for a builder that constructs view models from domain models.
/// </summary>
public interface IAlbumModelBuilder
{
    /// <summary>
    /// Creates a <see cref="AlbumViewModel"/> from a domain <see cref="Album"/>.
    /// </summary>
    /// <param name="album">The source album domain model.</param>
    /// <returns>A populated <see cref="AlbumViewModel"/>.</returns>
    AlbumViewModel Build(Album album);
}

#endregion

/// <summary>
/// Methods for constructing view models from domain models.
/// </summary>
public class AlbumModelBuilder : IAlbumModelBuilder
{
    /// <inheritdoc />
    public AlbumViewModel Build(Album album)
    {
        ArgumentNullException.ThrowIfNull(album);
        return new(album.Title, album.Artist, album.Genre, album.Description, album.Year);
    }
}
