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

/// <summary>
/// View model used by the UI to display book information.
/// </summary>
/// <param name="Title">Gets the book title.</param>
/// <param name="Author">Gets the author of the book.</param>
/// <param name="Genre">Gets the genre label for the book.</param>
/// <param name="Description">Gets a brief description of the book.</param>
/// <param name="Year">Gets the publication year of the book.</param>
public record BookViewModel(string Title, string Author, string Genre, string Description, int Year);

/// <summary>
/// View model used by the UI to display album information.
/// </summary>
/// <param name="Title">Gets the album title.</param>
/// <param name="Artist">Gets the artist of the album.</param>
/// <param name="Genre">Gets the genre label for the album.</param>
/// <param name="Description">Gets a brief description of the album.</param>
/// <param name="Year">Gets the release year of the album.</param>
public record AlbumViewModel(string Title, string Artist, string Genre, string Description, int Year);

/// <summary>
/// View model used by the UI to display a generated number.
/// </summary>
/// <param name="DieType">Gets the type of die used (e.g., d20).</param>
/// <param name="Result">Gets the randomly generated number.</param>
public record NumberViewModel(string DieType, int Result);
