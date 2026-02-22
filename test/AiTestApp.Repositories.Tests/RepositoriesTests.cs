using AiTestApp.Repositories.Contracts;
using NSubstitute;
using System.Text.Json;

namespace AiTestApp.Repositories.Tests;

public sealed class RepositoriesTests
{
    private readonly ITvShowsJsonDataSourceRepository tvShowsDataSource = Substitute.For<ITvShowsJsonDataSourceRepository>();
    private readonly IBooksJsonDataSourceRepository booksDataSource = Substitute.For<IBooksJsonDataSourceRepository>();
    private readonly IAlbumsJsonDataSourceRepository albumsDataSource = Substitute.For<IAlbumsJsonDataSourceRepository>();

    #region | TESTS: TvShowsRepository |

    [Fact]
    public void TvShows_GetAll_ShouldReturnItemsFromJson()
    {
        // Arrange
        var objUt = BuildTvShowsRepository();
        var items = new List<TvShow> { new("Show 1", "D", "U", "G", 2024) };
        tvShowsDataSource.ReadRawJson().Returns(JsonSerializer.Serialize(items));

        // Act
        var result = objUt.GetAll().ToList();

        // Assert
        result.Should().HaveCount(1);
        result[0].Title.Should().Be("Show 1");
    }

    #endregion

    #region | TESTS: BooksRepository |

    [Fact]
    public void Books_GetAll_ShouldReturnItemsFromJson()
    {
        // Arrange
        var objUt = BuildBooksRepository();
        var items = new List<Book> { new("Book 1", "A", "G", "D", 2024) };
        booksDataSource.ReadRawJson().Returns(JsonSerializer.Serialize(items));

        // Act
        var result = objUt.GetAll().ToList();

        // Assert
        result.Should().HaveCount(1);
        result[0].Title.Should().Be("Book 1");
    }

    #endregion

    #region | TESTS: AlbumsRepository |

    [Fact]
    public void Albums_GetAll_ShouldReturnItemsFromJson()
    {
        // Arrange
        var objUt = BuildAlbumsRepository();
        var items = new List<Album> { new("Album 1", "A", "G", "D", 2024) };
        albumsDataSource.ReadRawJson().Returns(JsonSerializer.Serialize(items));

        // Act
        var result = objUt.GetAll().ToList();

        // Assert
        result.Should().HaveCount(1);
        result[0].Title.Should().Be("Album 1");
    }

    #endregion

    #region | Supporting Methods |

    private ITvShowsRepository BuildTvShowsRepository() => new TvShowsRepository(tvShowsDataSource);
    private IBooksRepository BuildBooksRepository() => new BooksRepository(booksDataSource);
    private IAlbumsRepository BuildAlbumsRepository() => new AlbumsRepository(albumsDataSource);

    #endregion
}
