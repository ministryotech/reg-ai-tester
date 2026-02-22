namespace AiTestApp.Models;

/// <summary>
/// View model used by the UI to display album information.
/// </summary>
/// <param name="Title">Gets the album title.</param>
/// <param name="Artist">Gets the artist of the album.</param>
/// <param name="Genre">Gets the genre label for the album.</param>
/// <param name="Description">Gets a brief description of the album.</param>
/// <param name="Year">Gets the release year of the album.</param>
public record AlbumViewModel(string Title, string Artist, string Genre, string Description, int Year);
