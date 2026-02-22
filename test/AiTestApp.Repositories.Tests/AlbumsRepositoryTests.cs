using AiTestApp.Repositories.Contracts;
using NSubstitute;
using System.Text.Json;

namespace AiTestApp.Repositories.Tests;

public sealed class AlbumsRepositoryTests
{
    private readonly IAlbumsJsonDataSourceRepository albumsDataSource = Substitute.For<IAlbumsJsonDataSourceRepository>();

    #region | TESTS: GetAll |

    [Fact]
    public void GetAll_ShouldReturnItemsFromJson()
    {
        // Arrange
        var objUt = BuildObjUt(albumsDataSource);
        var items = new List<Album> { new("Album 1", "A", "G", "D", 2024) };
        albumsDataSource.ReadRawJson().Returns(JsonSerializer.Serialize(items));

        // Act
        var result = objUt.GetAll();

        // Assert
        result.Should().HaveCount(1);
        result[0].Title.Should().Be("Album 1");
    }

    #endregion

    #region | Supporting Methods |

    private static AlbumsRepository BuildObjUt(IAlbumsJsonDataSourceRepository albumsDataSource) => new(albumsDataSource);

    #endregion
}
