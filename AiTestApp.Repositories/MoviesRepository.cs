using AiTestApp.Repositories.Models;

namespace AiTestApp.Repositories;

/// <summary>
/// A repository that provides access to a static list of recent movies.
/// </summary>
public class MoviesRepository : IMoviesRepository
{
    /// <summary>
    /// A static list of movies used as the data source.
    /// </summary>
    private static readonly List<Movie> RecentMovies = new()
    {
        new Movie
        {
            Title = "Dune: Part Two",
            Year = 2024,
            Genre = "Sci-Fi / Adventure",
            Description = "Paul Atreides unites with Chani and the Fremen while on a warpath of revenge against the conspirators who destroyed his family.",
            PosterUrl = "https://image.tmdb.org/t/p/w500/8b8R8lS8M9vR9m9A8m5N1u8L3O.jpg"
        },
        new Movie
        {
            Title = "Deadpool & Wolverine",
            Year = 2024,
            Genre = "Action / Comedy",
            Description = "Wolverine is recovering from his injuries when he crosses paths with the loudmouth, Deadpool. They team up to defeat a common enemy.",
            PosterUrl = "https://image.tmdb.org/t/p/w500/8cdWjvZQUmOZp9vTDyZ4mc6Yy1A.jpg"
        },
        new Movie
        {
            Title = "Inside Out 2",
            Year = 2024,
            Genre = "Animation / Family",
            Description = "Follow Riley, in her teenage years, encountering new emotions.",
            PosterUrl = "https://image.tmdb.org/t/p/w500/vpnVM9B6NMmQpWeZvzLv1oYKyCq.jpg"
        },
        new Movie
        {
            Title = "The Beekeeper",
            Year = 2024,
            Genre = "Action / Thriller",
            Description = "One man's brutal campaign for vengeance takes on national stakes after he is revealed to be a former operative of a powerful and clandestine organization known as \"Beekeepers\".",
            PosterUrl = "https://image.tmdb.org/t/p/w500/A7EUMvGPTZRi0bnF1sVq19pUvSs.jpg"
        },
        new Movie
        {
            Title = "Gladiator II",
            Year = 2024,
            Genre = "Action / Drama",
            Description = "After his home is conquered by the tyrannical Emperors who now lead Rome, Lucius is forced to enter the Colosseum and must look to his past to find strength to return the glory of Rome to its people.",
            PosterUrl = "https://image.tmdb.org/t/p/w500/2cSTv2sTvWBM5Gv97S9Y9R9R9R9.jpg"
        }
    };

    /// <summary>
    /// Retrieves all movies from the static data source.
    /// </summary>
    /// <returns>An enumerable sequence containing all movies.</returns>
    public IEnumerable<Movie> GetAllMovies()
    {
        return RecentMovies;
    }
}
