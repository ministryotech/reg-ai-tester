using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.ModelBuilders;

#region | Interface |

/// <summary>
/// Interface for a builder that constructs view models from domain models.
/// </summary>
public interface IBookModelBuilder
{
    /// <summary>
    /// Creates a <see cref="BookViewModel"/> from a domain <see cref="Book"/>.
    /// </summary>
    /// <param name="book">The source book domain model.</param>
    /// <returns>A populated <see cref="BookViewModel"/>.</returns>
    BookViewModel Build(Book book);
}

#endregion

/// <summary>
/// Methods for constructing view models from domain models.
/// </summary>
public class BookModelBuilder : IBookModelBuilder
{
    /// <inheritdoc />
    public BookViewModel Build(Book book)
    {
        ArgumentNullException.ThrowIfNull(book);
        return new(book.Title, book.Author, book.Genre, book.Description, book.Year);
    }
}
