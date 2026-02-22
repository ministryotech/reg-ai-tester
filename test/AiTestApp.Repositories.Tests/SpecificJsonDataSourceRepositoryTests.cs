namespace AiTestApp.Repositories.Tests;

public sealed class SpecificJsonDataSourceRepositoryTests
{
    #region | TESTS: TvShowsJsonDataSourceRepository |

    [Fact]
    public void TvShowsDataSource_ReadRawJson_ShouldReturnContent()
    {
        // Arrange
        var objUt = BuildTvShowsDataSource();

        // Act
        var result = objUt.ReadRawJson();

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Contain("The Expanse");
    }

    #endregion

    #region | TESTS: BooksJsonDataSourceRepository |

    [Fact]
    public void BooksDataSource_ReadRawJson_ShouldReturnContent()
    {
        // Arrange
        var objUt = BuildBooksDataSource();

        // Act
        var result = objUt.ReadRawJson();

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Contain("Dune");
    }

    #endregion

    #region | TESTS: AlbumsJsonDataSourceRepository |

    [Fact]
    public void AlbumsDataSource_ReadRawJson_ShouldReturnContent()
    {
        // Arrange
        var objUt = BuildAlbumsDataSource();

        // Act
        var result = objUt.ReadRawJson();

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Contain("The Dark Side of the Moon");
    }

    #endregion

    #region | Supporting Methods |

    private static TvShowsJsonDataSourceRepository BuildTvShowsDataSource() => new();
    private static BooksJsonDataSourceRepository BuildBooksDataSource() => new();
    private static AlbumsJsonDataSourceRepository BuildAlbumsDataSource() => new();

    #endregion
}
