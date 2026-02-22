using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Services;

#region | Interfaces |

/// <summary>
/// Interface for a service that manages TV show operations.
/// </summary>
public interface ITvShowsService
{
    /// <summary>
    /// Retrieves a random TV show view model.
    /// </summary>
    /// <param name="lastTitle">The title of the last TV show shown.</param>
    /// <returns>A randomly selected TV show view model.</returns>
    TvShowViewModel GetRandom(string? lastTitle = null);
}

/// <summary>
/// Interface for a service that manages book operations.
/// </summary>
public interface IBooksService
{
    /// <summary>
    /// Retrieves a random book view model within a specific genre.
    /// </summary>
    /// <param name="genre">The genre to select from.</param>
    /// <param name="lastTitle">The title of the last book shown.</param>
    /// <returns>A randomly selected book view model.</returns>
    BookViewModel GetRandom(string genre, string? lastTitle = null);
}

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

/// <summary>
/// Interface for a service that generates random numbers from dice.
/// </summary>
public interface IDiceService
{
    /// <summary>
    /// Generates a random number from the specified die type.
    /// </summary>
    /// <param name="dieType">The type of die (e.g., d4, d20).</param>
    /// <returns>A view model containing the result.</returns>
    NumberViewModel Roll(string dieType);
}

#endregion

#region | Implementations |

/// <summary>
/// Service that manages TV show operations.
/// </summary>
public class TvShowsService(ITvShowsRepository repository, IViewModelBuilder builder) : ITvShowsService
{
    /// <inheritdoc />
    public TvShowViewModel GetRandom(string? lastTitle = null)
    {
        var shows = repository.GetAll().ToList();
        if (shows.Count == 0)
            throw new InvalidOperationException("No TV shows found.");

        var pool = string.IsNullOrWhiteSpace(lastTitle)
            ? shows
            : shows.Where(s => s.Title != lastTitle).ToList();

        if (pool.Count == 0)
            pool = shows;

        var random = new Random();
        return builder.Build(pool[random.Next(pool.Count)]);
    }
}

/// <summary>
/// Service that manages book operations.
/// </summary>
public class BooksService(IBooksRepository repository, IViewModelBuilder builder) : IBooksService
{
    /// <inheritdoc />
    public BookViewModel GetRandom(string genre, string? lastTitle = null)
    {
        var books = repository.GetAll().Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
        if (books.Count == 0)
            throw new InvalidOperationException($"No books found for genre: {genre}");

        var pool = string.IsNullOrWhiteSpace(lastTitle)
            ? books
            : books.Where(b => b.Title != lastTitle).ToList();

        if (pool.Count == 0)
            pool = books;

        var random = new Random();
        return builder.Build(pool[random.Next(pool.Count)]);
    }
}

/// <summary>
/// Service that manages album operations.
/// </summary>
public class AlbumsService(IAlbumsRepository repository, IViewModelBuilder builder) : IAlbumsService
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

/// <summary>
/// Service that generates random numbers from dice.
/// </summary>
public class DiceService : IDiceService
{
    /// <inheritdoc />
    public NumberViewModel Roll(string dieType)
    {
        var sides = dieType.ToLower() switch
        {
            "d4" => 4,
            "d6" => 6,
            "d8" => 8,
            "d10" => 10,
            "d12" => 12,
            "d20" => 20,
            "d100" => 100,
            _ => throw new ArgumentException("Invalid die type", nameof(dieType))
        };

        var random = new Random();
        return new NumberViewModel(dieType, random.Next(1, sides + 1));
    }
}

#endregion
