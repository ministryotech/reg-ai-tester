namespace AiTestApp.Models;

/// <summary>
/// View model used by the UI to display book information.
/// </summary>
/// <param name="Title">Gets the book title.</param>
/// <param name="Author">Gets the author of the book.</param>
/// <param name="Genre">Gets the genre label for the book.</param>
/// <param name="Description">Gets a brief description of the book.</param>
/// <param name="Year">Gets the publication year of the book.</param>
public record BookViewModel(string Title, string Author, string Genre, string Description, int Year);
