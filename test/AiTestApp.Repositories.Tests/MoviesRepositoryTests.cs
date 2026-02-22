using AiTestApp.Repositories;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Repositories.Tests;

public sealed class MoviesRepositoryTests
{
    private MoviesRepository BuildObjUt() => new();

    #region | TESTS: GetAllMovies |

    [Fact]
    public void GetAllMovies_ShouldReturnNonEmptyListOfMovies()
    {
        // Arrange
        var objUt = BuildObjUt();

        // Act
        var result = objUt.GetAllMovies();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(5);
        result.Should().AllBeOfType<Movie>();
    }

    [Fact]
    public void GetAllMovies_ShouldContainExpectedMovies()
    {
        // Arrange
        var objUt = BuildObjUt();

        // Act
        var result = objUt.GetAllMovies().ToList();

        // Assert
        result.Should().Contain(m => m.Title == "Dune: Part Two");
        result.Should().Contain(m => m.Title == "Deadpool & Wolverine");
        result.Should().Contain(m => m.Title == "Inside Out 2");
        result.Should().Contain(m => m.Title == "The Beekeeper");
        result.Should().Contain(m => m.Title == "Gladiator II");
    }

    #endregion
}
