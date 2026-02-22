using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Repositories;

#region | Interface |

/// <summary>
/// Interface for a repository that manages movie data.
/// </summary>
public interface IMoviesRepository
{
    /// <summary>
    /// Retrieves all available movies.
    /// </summary>
    /// <returns>An enumerable collection of all movies.</returns>
    IEnumerable<Movie> GetAllMovies();
}

#endregion

/// <summary>
/// A repository that provides access to a static list of recent movies.
/// </summary>
public class MoviesRepository : IMoviesRepository
{
    /// <summary>
    /// A static list of movies used as the data source.
    /// </summary>
    private static readonly List<Movie> RecentMovies =
    [
        new("Dune: Part Two", "Paul Atreides unites with Chani and the Fremen while on a warpath of revenge against the conspirators who destroyed his family.", "https://image.tmdb.org/t/p/w500/8b8R8lS8M9vR9m9A8m5N1u8L3O.jpg", "Sci-Fi / Adventure", 2024),
        new("Deadpool & Wolverine", "Wolverine is recovering from his injuries when he crosses paths with the loudmouth, Deadpool. They team up to defeat a common enemy.", "https://image.tmdb.org/t/p/w500/8cdWjvZQUmOZp9vTDyZ4mc6Yy1A.jpg", "Action / Comedy", 2024),
        new("Inside Out 2", "Follow Riley, in her teenage years, encountering new emotions.", "https://image.tmdb.org/t/p/w500/vpnVM9B6NMmQpWeZvzLv1oYKyCq.jpg", "Animation / Family", 2024),
        new("The Beekeeper", "One man's brutal campaign for vengeance takes on national stakes after he is revealed to be a former operative of a powerful and clandestine organization known as \"Beekeepers\".", "https://image.tmdb.org/t/p/w500/A7EUMvGPTZRi0bnF1sVq19pUvSs.jpg", "Action / Thriller", 2024),
        new("Gladiator II", "After his home is conquered by the tyrannical Emperors who now lead Rome, Lucius is forced to enter the Colosseum and must look to his past to find strength to return the glory of Rome to its people.", "https://image.tmdb.org/t/p/w500/2cSTv2sTvWBM5Gv97S9Y9R9R9R9.jpg", "Action / Drama", 2024)
    ];

    /// <inheritdoc />
    public IEnumerable<Movie> GetAllMovies() => RecentMovies;
}
