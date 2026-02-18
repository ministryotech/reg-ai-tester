namespace AiTestApp.Models;

/// <summary>
/// View model used by the UI to display movie information.
/// </summary>
/// <param name="Title">Gets or sets the movie title.</param>
/// <param name="Description">Gets or sets a brief description of the movie.</param>
/// <param name="PosterUrl">Gets or sets the URL of the movie poster image.</param>
/// <param name="Genre">Gets or sets the genre label(s) for the movie.</param>
/// <param name="Year">Gets or sets the release year of the movie.</param>
public record MovieViewModel(string Title, string Description, string PosterUrl, string Genre, int Year);
