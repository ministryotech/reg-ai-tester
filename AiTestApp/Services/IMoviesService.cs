using AiTestApp.Models;

namespace AiTestApp.Services;

/// <summary>
/// Interface for a service that manages movie operations.
/// </summary>
public interface IMoviesService
{
    /// <summary>
    /// Retrieves a random movie view model, optionally excluding a specific movie title.
    /// </summary>
    /// <param name="lastTitle">The title of the last movie shown, to be excluded from the random selection.</param>
    /// <returns>A randomly selected movie view model.</returns>
    MovieViewModel GetRandomMovie(string? lastTitle = null);
}
