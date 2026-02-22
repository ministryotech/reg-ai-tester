namespace AiTestApp.Repositories;

#region | Interface |

/// <summary>
/// Interface for a TV shows-specific JSON data source.
/// </summary>
public interface ITvShowsJsonDataSourceRepository : IJsonDataSourceRepository;

#endregion

/// <summary>
/// A concrete data source repository for TV shows that uses a hardcoded file path.
/// </summary>
public class TvShowsJsonDataSourceRepository() : JsonDataSourceRepository("tv-shows-data.json"), ITvShowsJsonDataSourceRepository;
