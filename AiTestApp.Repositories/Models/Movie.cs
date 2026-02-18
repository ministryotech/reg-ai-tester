namespace AiTestApp.Repositories.Models;

/// <summary>
/// Represents a movie entity in the system.
/// </summary>
public class Movie
{
    /// <summary>
    /// Gets or sets the title of the movie.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a brief description of the movie.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the URL for the movie's poster image.
    /// </summary>
    public string PosterUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the genre or genres associated with the movie.
    /// </summary>
    public string Genre { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the year the movie was released.
    /// </summary>
    public int Year { get; set; }
}
