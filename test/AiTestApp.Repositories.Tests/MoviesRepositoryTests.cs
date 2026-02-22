using AiTestApp.Repositories;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Repositories.Tests;

public class MoviesRepositoryTests
{
    private readonly MoviesRepository _sut = new();

    [Fact]
    public void GetAllMovies_ShouldReturnNonEmptyListOfMovies()
    {
        // Act
        var result = _sut.GetAllMovies();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(5);
        result.Should().AllBeOfType<Movie>();
    }

    [Fact]
    public void GetAllMovies_ShouldContainExpectedMovies()
    {
        // Act
        var result = _sut.GetAllMovies().ToList();

        // Assert
        result.Should().Contain(m => m.Title == "Dune: Part Two");
        result.Should().Contain(m => m.Title == "Deadpool & Wolverine");
        result.Should().Contain(m => m.Title == "Inside Out 2");
        result.Should().Contain(m => m.Title == "The Beekeeper");
        result.Should().Contain(m => m.Title == "Gladiator II");
    }
}
