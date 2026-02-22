namespace AiTestApp.Repositories.Contracts;

/// <summary>
/// Represents a movie entity in the system.
/// </summary>
/// <param name="Title">Gets or sets the title of the movie.</param>
/// <param name="Description">Gets or sets a brief description of the movie.</param>
/// <param name="PosterUrl">Gets or sets the URL for the movie's poster image.</param>
/// <param name="Genre">Gets or sets the genre or genres associated with the movie.</param>
/// <param name="Year">Gets or sets the year the movie was released.</param>
public record Movie(string Title, string Description, string PosterUrl, string Genre, int Year);
