using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Repositories;

/// <summary>
/// A data source repository that loads raw JSON from a specified file.
/// </summary>
/// <param name="filePath">The path and name of the JSON file to read.</param>
public class JsonDataSourceRepository(string filePath) : IJsonDataSourceRepository
{
    /// <inheritdoc />
    public string ReadRawJson() => File.ReadAllText(filePath);
}
