namespace AiTestApp.Repositories;

#region | Interface |

/// <summary>
/// Interface for a books-specific JSON data source.
/// </summary>
public interface IBooksJsonDataSourceRepository : IJsonDataSourceRepository;

#endregion

/// <summary>
/// A concrete data source repository for books that uses a hardcoded file path.
/// </summary>
public class BooksJsonDataSourceRepository() : JsonDataSourceRepository("books-data.json"), IBooksJsonDataSourceRepository;
