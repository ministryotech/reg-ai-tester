using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories;
using AiTestApp.Repositories.Contracts;
using AiTestApp.Services;
using NSubstitute;

namespace AiTestApp.Tests.Services;

public class MoviesServiceTests
{
    private readonly IMoviesRepository _moviesRepository = Substitute.For<IMoviesRepository>();
    private readonly IMovieModelBuilder _movieModelBuilder = Substitute.For<IMovieModelBuilder>();
    private readonly MoviesService _sut;

    public MoviesServiceTests()
    {
        _sut = new MoviesService(_moviesRepository, _movieModelBuilder);
    }

    [Fact]
    public void GetRandomMovie_ShouldReturnMovie_WhenRepositoryHasMovies()
    {
        // Arrange
        var movies = new List<Movie>
        {
            new("Movie 1", "D1", "U1", "G1", 2021),
            new("Movie 2", "D2", "U2", "G2", 2022)
        };
        _moviesRepository.GetAllMovies().Returns(movies);
        _movieModelBuilder.Build(Arg.Any<Movie>()).Returns(callInfo => 
        {
            var m = callInfo.Arg<Movie>();
            return new MovieViewModel(m.Title, m.Description, m.PosterUrl, m.Genre, m.Year);
        });

        // Act
        var result = _sut.GetRandomMovie();

        // Assert
        result.Should().NotBeNull();
        movies.Select(m => m.Title).Should().Contain(result.Title);
    }

    [Fact]
    public void GetRandomMovie_ShouldExcludeLastTitle_WhenPoolIsNotEmpty()
    {
        // Arrange
        var movies = new List<Movie>
        {
            new("Movie 1", "D1", "U1", "G1", 2021),
            new("Movie 2", "D2", "U2", "G2", 2022)
        };
        _moviesRepository.GetAllMovies().Returns(movies);
        _movieModelBuilder.Build(Arg.Any<Movie>()).Returns(callInfo => 
        {
            var m = callInfo.Arg<Movie>();
            return new MovieViewModel(m.Title, m.Description, m.PosterUrl, m.Genre, m.Year);
        });

        // Act
        var result = _sut.GetRandomMovie("Movie 1");

        // Assert
        result.Title.Should().Be("Movie 2");
    }

    [Fact]
    public void GetRandomMovie_ShouldReturnAnyMovie_WhenLastTitleIsOnlyOption()
    {
        // Arrange
        var movies = new List<Movie>
        {
            new("Movie 1", "D1", "U1", "G1", 2021)
        };
        _moviesRepository.GetAllMovies().Returns(movies);
        _movieModelBuilder.Build(Arg.Any<Movie>()).Returns(callInfo => 
        {
            var m = callInfo.Arg<Movie>();
            return new MovieViewModel(m.Title, m.Description, m.PosterUrl, m.Genre, m.Year);
        });

        // Act
        var result = _sut.GetRandomMovie("Movie 1");

        // Assert
        result.Title.Should().Be("Movie 1");
    }

    [Fact]
    public void GetRandomMovie_ShouldThrowException_WhenRepositoryIsEmpty()
    {
        // Arrange
        _moviesRepository.GetAllMovies().Returns(Enumerable.Empty<Movie>());

        // Act
        var act = () => _sut.GetRandomMovie();

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("No movies found in the repository.");
    }
}
