using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Tests.ModelBuilders;

public class MovieModelBuilderTests
{
    private readonly MovieModelBuilder _sut = new();

    [Fact]
    public void Build_ShouldMapAllPropertiesCorrectly()
    {
        // Arrange
        var movie = new Movie("Title", "Description", "Url", "Genre", 2024);

        // Act
        var result = _sut.Build(movie);

        // Assert
        result.Title.Should().Be(movie.Title);
        result.Description.Should().Be(movie.Description);
        result.PosterUrl.Should().Be(movie.PosterUrl);
        result.Genre.Should().Be(movie.Genre);
        result.Year.Should().Be(movie.Year);
    }
}
