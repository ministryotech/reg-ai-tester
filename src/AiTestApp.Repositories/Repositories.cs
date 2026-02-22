using System.Text.Json;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Repositories;

#region | TV Shows |

/// <summary>
/// A repository that provides access to TV shows from a JSON data source.
/// </summary>
/// <param name="jsonDataSource">The source of raw JSON TV show data.</param>
public class TvShowsRepository(ITvShowsJsonDataSourceRepository jsonDataSource) : ITvShowsRepository
{
    /// <inheritdoc />
    public IEnumerable<TvShow> GetAll() =>
        JsonSerializer.Deserialize<List<TvShow>>(jsonDataSource.ReadRawJson()) ?? [];
}

#endregion

#region | Books |

/// <summary>
/// A repository that provides access to books from a JSON data source.
/// </summary>
/// <param name="jsonDataSource">The source of raw JSON book data.</param>
public class BooksRepository(IBooksJsonDataSourceRepository jsonDataSource) : IBooksRepository
{
    /// <inheritdoc />
    public IEnumerable<Book> GetAll() =>
        JsonSerializer.Deserialize<List<Book>>(jsonDataSource.ReadRawJson()) ?? [];
}

#endregion

#region | Albums |

/// <summary>
/// A repository that provides access to albums from a JSON data source.
/// </summary>
/// <param name="jsonDataSource">The source of raw JSON album data.</param>
public class AlbumsRepository(IAlbumsJsonDataSourceRepository jsonDataSource) : IAlbumsRepository
{
    /// <inheritdoc />
    public IEnumerable<Album> GetAll() =>
        JsonSerializer.Deserialize<List<Album>>(jsonDataSource.ReadRawJson()) ?? [];
}

#endregion
