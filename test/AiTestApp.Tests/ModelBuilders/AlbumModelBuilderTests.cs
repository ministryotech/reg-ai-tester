using AiTestApp.ModelBuilders;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Tests.ModelBuilders;

public sealed class AlbumModelBuilderTests
{
    #region | TESTS: Build |

    [Fact]
    public void Build_ShouldMapAllPropertiesCorrectly()
    {
        // Arrange
        var objUt = BuildObjUt();
        var album = new Album("Album", "Artist", "Genre", "Desc", 2024);

        // Act
        var result = objUt.Build(album);

        // Assert
        result.Title.Should().Be(album.Title);
        result.Artist.Should().Be(album.Artist);
        result.Genre.Should().Be(album.Genre);
        result.Description.Should().Be(album.Description);
        result.Year.Should().Be(album.Year);
    }

    [Fact]
    public void Build_ShouldThrowArgumentNullException_WhenAlbumIsNull()
    {
        // Arrange
        var objUt = BuildObjUt();

        // Act
        var act = () => objUt.Build(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>().WithParameterName("album");
    }

    #endregion

    #region | Supporting Methods |

    private static AlbumModelBuilder BuildObjUt() => new();

    #endregion
}
