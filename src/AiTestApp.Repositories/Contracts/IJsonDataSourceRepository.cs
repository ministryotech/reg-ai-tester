namespace AiTestApp.Repositories.Contracts;

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
