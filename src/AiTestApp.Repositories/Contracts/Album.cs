namespace AiTestApp.Repositories.Contracts;

/// <summary>
/// Represents an album entity.
/// </summary>
/// <param name="Title">Gets or sets the title of the album.</param>
/// <param name="Artist">Gets or sets the artist of the album.</param>
/// <param name="Genre">Gets or sets the genre associated with the album.</param>
/// <param name="Description">Gets or sets a brief description of the album.</param>
/// <param name="Year">Gets or sets the year the album was released.</param>
public record Album(string Title, string Artist, string Genre, string Description, int Year);
