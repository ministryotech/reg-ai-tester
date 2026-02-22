namespace AiTestApp.Repositories;

#region | Interface |

/// <summary>
/// Interface for an albums-specific JSON data source.
/// </summary>
public interface IAlbumsJsonDataSourceRepository : IJsonDataSourceRepository;

#endregion

/// <summary>
/// A concrete data source repository for albums that uses a hardcoded file path.
/// </summary>
public class AlbumsJsonDataSourceRepository() : JsonDataSourceRepository("albums-data.json"), IAlbumsJsonDataSourceRepository;
