namespace AiTestApp.Repositories;

#region | Interface |

/// <summary>
/// Interface for a data source that provides raw JSON input from a file.
/// </summary>
public interface IJsonDataSourceRepository
{
    /// <summary>
    /// Reads the raw JSON content from the data source.
    /// </summary>
    /// <returns>The JSON string containing movie data.</returns>
    string ReadRawJson();
}

/// <summary>
/// Interface for a movies-specific JSON data source.
/// </summary>
public interface IMoviesJsonDataSourceRepository : IJsonDataSourceRepository
{
}

#endregion

/// <summary>
/// An abstract data source repository that loads raw JSON from a specified file.
/// </summary>
/// <param name="filePath">The path and name of the JSON file to read.</param>
public abstract class JsonDataSourceRepository(string filePath) : IJsonDataSourceRepository
{
    /// <inheritdoc />
    public string ReadRawJson() => File.ReadAllText(filePath);
}

/// <summary>
/// A concrete data source repository for movies that uses a hardcoded file path.
/// </summary>
public class MoviesJsonDataSourceRepository() : JsonDataSourceRepository("test-movies.json"), IMoviesJsonDataSourceRepository
{
}
