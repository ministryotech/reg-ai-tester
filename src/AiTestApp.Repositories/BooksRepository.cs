using System.Text.Json;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Repositories;

#region | Interface |

/// <summary>
/// Interface for a repository that manages book data.
/// </summary>
public interface IBooksRepository
{
    /// <summary>
    /// Retrieves all available books.
    /// </summary>
    /// <returns>An enumerable collection of all books.</returns>
    IEnumerable<Book> GetAll();
}

#endregion

/// <summary>
/// A repository that provides access to books from a JSON data source.
/// </summary>
/// <param name="jsonDataSource">The source of raw JSON book data.</param>
public class BooksRepository(IBooksJsonDataSourceRepository jsonDataSource) : IBooksRepository
{
    /// <inheritdoc />
    public IEnumerable<Book> GetAll() =>
        JsonSerializer.Deserialize<List<Book>>(jsonDataSource.ReadRawJson()) ?? [];
}
