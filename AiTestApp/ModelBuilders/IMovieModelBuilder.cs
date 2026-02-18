using AiTestApp.Models;
using AiTestApp.Repositories.Models;

namespace AiTestApp.ModelBuilders;

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
