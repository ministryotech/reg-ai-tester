using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Tests.ModelBuilders;

public sealed class MovieModelBuilderTests
{
    private MovieModelBuilder BuildObjUt() => new();

    #region | TESTS: Build |

    [Fact]
    public void Build_ShouldMapAllPropertiesCorrectly()
    {
        // Arrange
        var objUt = BuildObjUt();
        var movie = new Movie("Title", "Description", "Url", "Genre", 2024);

        // Act
        var result = objUt.Build(movie);

        // Assert
        result.Title.Should().Be(movie.Title);
        result.Description.Should().Be(movie.Description);
        result.PosterUrl.Should().Be(movie.PosterUrl);
        result.Genre.Should().Be(movie.Genre);
        result.Year.Should().Be(movie.Year);
    }

    #endregion
}
