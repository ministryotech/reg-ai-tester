namespace AiTestApp.Repositories.Contracts;

/// <summary>
/// Represents a book entity.
/// </summary>
/// <param name="Title">Gets or sets the title of the book.</param>
/// <param name="Author">Gets or sets the author of the book.</param>
/// <param name="Genre">Gets or sets the genre associated with the book.</param>
/// <param name="Description">Gets or sets a brief description of the book.</param>
/// <param name="Year">Gets or sets the year the book was published.</param>
public record Book(string Title, string Author, string Genre, string Description, int Year);
