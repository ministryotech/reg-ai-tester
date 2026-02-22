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
