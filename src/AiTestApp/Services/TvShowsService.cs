using AiTestApp.Repositories;
using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Services;

#region | Interface |

/// <summary>
/// Interface for a service that manages TV show operations.
/// </summary>
public interface ITvShowsService
{
    /// <summary>
    /// Retrieves a random TV show view model.
    /// </summary>
    /// <param name="lastTitle">The title of the last TV show shown.</param>
    /// <returns>A randomly selected TV show view model.</returns>
    TvShowViewModel GetRandom(string? lastTitle = null);
}

#endregion

/// <summary>
/// Service that manages TV show operations.
/// </summary>
public class TvShowsService(ITvShowsRepository repository, ITvShowModelBuilder builder) : ITvShowsService
{
    /// <inheritdoc />
    public TvShowViewModel GetRandom(string? lastTitle = null)
    {
        var shows = repository.GetAll().ToList();
        if (shows.Count == 0)
            throw new InvalidOperationException("No TV shows found.");

        var pool = string.IsNullOrWhiteSpace(lastTitle)
            ? shows
            : shows.Where(s => s.Title != lastTitle).ToList();

        if (pool.Count == 0)
            pool = shows;

        var random = new Random();
        return builder.Build(pool[random.Next(pool.Count)]);
    }
}
