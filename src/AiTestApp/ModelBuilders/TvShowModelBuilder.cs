using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.ModelBuilders;

#region | Interface |

/// <summary>
/// Interface for a builder that constructs view models from domain models.
/// </summary>
public interface ITvShowModelBuilder
{
    /// <summary>
    /// Creates a <see cref="TvShowViewModel"/> from a domain <see cref="TvShow"/>.
    /// </summary>
    /// <param name="tvShow">The source TV show domain model.</param>
    /// <returns>A populated <see cref="TvShowViewModel"/>.</returns>
    TvShowViewModel Build(TvShow tvShow);
}

#endregion

/// <summary>
/// Methods for constructing view models from domain models.
/// </summary>
public class TvShowModelBuilder : ITvShowModelBuilder
{
    /// <inheritdoc />
    public TvShowViewModel Build(TvShow tvShow)
    {
        ArgumentNullException.ThrowIfNull(tvShow);
        return new(tvShow.Title, tvShow.Description, tvShow.PosterUrl, tvShow.Genre, tvShow.Year);
    }
}
