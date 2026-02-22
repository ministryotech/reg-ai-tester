using AiTestApp.ModelBuilders;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Tests.ModelBuilders;

public sealed class TvShowModelBuilderTests
{
    #region | TESTS: Build |

    [Fact]
    public void Build_ShouldMapAllPropertiesCorrectly()
    {
        // Arrange
        var objUt = BuildObjUt();
        var show = new TvShow("Show", "Desc", "Url", "Genre", 2024);

        // Act
        var result = objUt.Build(show);

        // Assert
        result.Title.Should().Be(show.Title);
        result.Description.Should().Be(show.Description);
        result.PosterUrl.Should().Be(show.PosterUrl);
        result.Genre.Should().Be(show.Genre);
        result.Year.Should().Be(show.Year);
    }

    [Fact]
    public void Build_ShouldThrowArgumentNullException_WhenTvShowIsNull()
    {
        // Arrange
        var objUt = BuildObjUt();

        // Act
        var act = () => objUt.Build(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>().WithParameterName("tvShow");
    }

    #endregion

    #region | Supporting Methods |

    private static TvShowModelBuilder BuildObjUt() => new();

    #endregion
}
