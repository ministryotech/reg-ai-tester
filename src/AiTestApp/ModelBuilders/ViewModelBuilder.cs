using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.ModelBuilders;

#region | Interface |

/// <summary>
/// Interface for a builder that constructs view models from domain models.
/// </summary>
public interface IViewModelBuilder
{
    /// <summary>
    /// Creates a <see cref="TvShowViewModel"/> from a domain <see cref="TvShow"/>.
    /// </summary>
    TvShowViewModel Build(TvShow tvShow);

    /// <summary>
    /// Creates a <see cref="BookViewModel"/> from a domain <see cref="Book"/>.
    /// </summary>
    BookViewModel Build(Book book);

    /// <summary>
    /// Creates a <see cref="AlbumViewModel"/> from a domain <see cref="Album"/>.
    /// </summary>
    AlbumViewModel Build(Album album);
}

#endregion

/// <summary>
/// Methods for constructing view models from domain models.
/// </summary>
public class ViewModelBuilder : IViewModelBuilder
{
    /// <inheritdoc />
    public TvShowViewModel Build(TvShow tvShow)
    {
        ArgumentNullException.ThrowIfNull(tvShow);
        return new(tvShow.Title, tvShow.Description, tvShow.PosterUrl, tvShow.Genre, tvShow.Year);
    }

    /// <inheritdoc />
    public BookViewModel Build(Book book)
    {
        ArgumentNullException.ThrowIfNull(book);
        return new(book.Title, book.Author, book.Genre, book.Description, book.Year);
    }

    /// <inheritdoc />
    public AlbumViewModel Build(Album album)
    {
        ArgumentNullException.ThrowIfNull(album);
        return new(album.Title, album.Artist, album.Genre, album.Description, album.Year);
    }
}
