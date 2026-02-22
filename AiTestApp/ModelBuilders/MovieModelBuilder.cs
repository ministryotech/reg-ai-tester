using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.ModelBuilders;

#region | Interface |

/// <summary>
/// Interface for a builder that constructs view models from domain models.
/// </summary>
public interface IMovieModelBuilder
{
    /// <summary>
    /// Creates a <see cref="MovieViewModel"/> from a domain <see cref="Movie"/>.
    /// </summary>
    /// <param name="movie">The source movie domain model.</param>
    /// <returns>A populated <see cref="MovieViewModel"/>.</returns>
    MovieViewModel Build(Movie movie);
}

#endregion

/// <summary>
/// Methods for constructing view models from domain models.
/// </summary>
public class MovieModelBuilder : IMovieModelBuilder
{
    /// <inheritdoc />
    public MovieViewModel Build(Movie movie) => new(movie.Title, movie.Description, movie.PosterUrl, movie.Genre, movie.Year);
}
