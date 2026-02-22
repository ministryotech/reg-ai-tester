namespace AiTestApp.Repositories.Contracts;

#region | TV Shows |

/// <summary>
/// Interface for a repository that manages TV show data.
/// </summary>
public interface ITvShowsRepository
{
    /// <summary>
    /// Retrieves all available TV shows.
    /// </summary>
    /// <returns>An enumerable collection of all TV shows.</returns>
    IEnumerable<TvShow> GetAll();
}

#endregion

#region | Books |

/// <summary>
/// Interface for a repository that manages book data.
/// </summary>
public interface IBooksRepository
{
    /// <summary>
    /// Retrieves all available books.
    /// </summary>
    /// <returns>An enumerable collection of all books.</returns>
    IEnumerable<Book> GetAll();
}

#endregion

#region | Albums |

/// <summary>
/// Interface for a repository that manages album data.
/// </summary>
public interface IAlbumsRepository
{
    /// <summary>
    /// Retrieves all available albums.
    /// </summary>
    /// <returns>An enumerable collection of all albums.</returns>
    IEnumerable<Album> GetAll();
}

#endregion
