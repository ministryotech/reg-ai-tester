namespace AiTestApp.Repositories.Contracts;

/// <summary>
/// Represents a TV show entity.
/// </summary>
/// <param name="Title">Gets or sets the title of the TV show.</param>
/// <param name="Description">Gets or sets a brief description of the TV show.</param>
/// <param name="PosterUrl">Gets or sets the URL for the TV show's poster image.</param>
/// <param name="Genre">Gets or sets the genre associated with the TV show.</param>
/// <param name="Year">Gets or sets the year the TV show premiered.</param>
public record TvShow(string Title, string Description, string PosterUrl, string Genre, int Year);

/// <summary>
/// Represents a book entity.
/// </summary>
/// <param name="Title">Gets or sets the title of the book.</param>
/// <param name="Author">Gets or sets the author of the book.</param>
/// <param name="Genre">Gets or sets the genre associated with the book.</param>
/// <param name="Description">Gets or sets a brief description of the book.</param>
/// <param name="Year">Gets or sets the year the book was published.</param>
public record Book(string Title, string Author, string Genre, string Description, int Year);

/// <summary>
/// Represents an album entity.
/// </summary>
/// <param name="Title">Gets or sets the title of the album.</param>
/// <param name="Artist">Gets or sets the artist of the album.</param>
/// <param name="Genre">Gets or sets the genre associated with the album.</param>
/// <param name="Description">Gets or sets a brief description of the album.</param>
/// <param name="Year">Gets or sets the year the album was released.</param>
public record Album(string Title, string Artist, string Genre, string Description, int Year);
