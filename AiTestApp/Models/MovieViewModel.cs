namespace AiTestApp.Models;

/// <summary>
/// View model used by the UI to display movie information.
/// </summary>
public class MovieViewModel
{
    /// <summary>
    /// Gets or sets the movie title.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a brief description of the movie.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the URL of the movie poster image.
    /// </summary>
    public string PosterUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the genre label(s) for the movie.
    /// </summary>
    public string Genre { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the release year of the movie.
    /// </summary>
    public int Year { get; set; }
}
