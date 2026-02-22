namespace AiTestApp.Repositories;

#region | TV Shows |

/// <summary>
/// Interface for a TV shows-specific JSON data source.
/// </summary>
public interface ITvShowsJsonDataSourceRepository : IJsonDataSourceRepository;

/// <summary>
/// A concrete data source repository for TV shows that uses a hardcoded file path.
/// </summary>
public class TvShowsJsonDataSourceRepository() : JsonDataSourceRepository("tv-shows-data.json"), ITvShowsJsonDataSourceRepository;

#endregion

#region | Books |

/// <summary>
/// Interface for a books-specific JSON data source.
/// </summary>
public interface IBooksJsonDataSourceRepository : IJsonDataSourceRepository;

/// <summary>
/// A concrete data source repository for books that uses a hardcoded file path.
/// </summary>
public class BooksJsonDataSourceRepository() : JsonDataSourceRepository("books-data.json"), IBooksJsonDataSourceRepository;

#endregion

#region | Albums |

/// <summary>
/// Interface for an albums-specific JSON data source.
/// </summary>
public interface IAlbumsJsonDataSourceRepository : IJsonDataSourceRepository;

/// <summary>
/// A concrete data source repository for albums that uses a hardcoded file path.
/// </summary>
public class AlbumsJsonDataSourceRepository() : JsonDataSourceRepository("albums-data.json"), IAlbumsJsonDataSourceRepository;

#endregion
