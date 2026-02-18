namespace AiTestApp.ModelBuilders;

using AiTestApp.Models;
using AiTestApp.Repositories.Models;

/// <summary>
/// Methods for constructing view models from domain models.
/// </summary>
public class MovieModelBuilder : IMovieModelBuilder
{
    /// <summary>
    /// Creates a <see cref="MovieViewModel"/> from a domain <see cref="Movie"/>.
    /// </summary>
    /// <param name="movie">The source movie domain model.</param>
    /// <returns>A populated <see cref="MovieViewModel"/>.</returns>
    public MovieViewModel Build(Movie movie)
    {
        return new MovieViewModel
        {
            Title = movie.Title,
            Description = movie.Description,
            PosterUrl = movie.PosterUrl,
            Genre = movie.Genre,
            Year = movie.Year
        };
    }
}
