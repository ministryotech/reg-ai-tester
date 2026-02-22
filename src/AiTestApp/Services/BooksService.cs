using AiTestApp.Repositories;
using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Services;

#region | Interface |

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

#endregion

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
