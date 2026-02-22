namespace AiTestApp.Models;

/// <summary>
/// View model used by the UI to display TV show information.
/// </summary>
/// <param name="Title">Gets the TV show title.</param>
/// <param name="Description">Gets a brief description of the TV show.</param>
/// <param name="PosterUrl">Gets the URL of the TV show poster image.</param>
/// <param name="Genre">Gets the genre label for the TV show.</param>
/// <param name="Year">Gets the premier year of the TV show.</param>
public record TvShowViewModel(string Title, string Description, string PosterUrl, string Genre, int Year);
