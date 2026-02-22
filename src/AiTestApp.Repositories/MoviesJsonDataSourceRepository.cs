namespace AiTestApp.Repositories;

#region | Interface |

/// <summary>
/// Interface for a movies-specific JSON data source.
/// </summary>
public interface IMoviesJsonDataSourceRepository : IJsonDataSourceRepository
{
}

#endregion

/// <summary>
/// A concrete data source repository for movies that uses a hardcoded file path.
/// </summary>
public class MoviesJsonDataSourceRepository() : JsonDataSourceRepository("test-movies.json"), IMoviesJsonDataSourceRepository
{
}
