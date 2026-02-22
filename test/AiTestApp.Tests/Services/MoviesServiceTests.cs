using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories;
using AiTestApp.Repositories.Contracts;
using AiTestApp.Services;
using NSubstitute;

namespace AiTestApp.Tests.Services;

public class MoviesServiceTests
{
    private readonly IMoviesRepository moviesRepository = Substitute.For<IMoviesRepository>();
    private readonly IMovieModelBuilder movieModelBuilder = Substitute.For<IMovieModelBuilder>();
    private readonly MoviesService objUt;

    public MoviesServiceTests()
    {
        objUt = new MoviesService(moviesRepository, movieModelBuilder);
    }

    #region | TESTS: GetRandomMovie |

    [Fact]
    public void GetRandomMovie_ShouldReturnMovie_WhenRepositoryHasMovies()
    {
        // Arrange
        var movies = new List<Movie>
        {
            new("Movie 1", "D1", "U1", "G1", 2021),
            new("Movie 2", "D2", "U2", "G2", 2022)
        };
        moviesRepository.GetAllMovies().Returns(movies);
        movieModelBuilder.Build(Arg.Any<Movie>()).Returns(callInfo => 
        {
            var m = callInfo.Arg<Movie>();
            return new MovieViewModel(m.Title, m.Description, m.PosterUrl, m.Genre, m.Year);
        });

        // Act
        var result = objUt.GetRandomMovie();

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
        moviesRepository.GetAllMovies().Returns(movies);
        movieModelBuilder.Build(Arg.Any<Movie>()).Returns(callInfo => 
        {
            var m = callInfo.Arg<Movie>();
            return new MovieViewModel(m.Title, m.Description, m.PosterUrl, m.Genre, m.Year);
        });

        // Act
        var result = objUt.GetRandomMovie("Movie 1");

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
        moviesRepository.GetAllMovies().Returns(movies);
        movieModelBuilder.Build(Arg.Any<Movie>()).Returns(callInfo => 
        {
            var m = callInfo.Arg<Movie>();
            return new MovieViewModel(m.Title, m.Description, m.PosterUrl, m.Genre, m.Year);
        });

        // Act
        var result = objUt.GetRandomMovie("Movie 1");

        // Assert
        result.Title.Should().Be("Movie 1");
    }

    [Fact]
    public void GetRandomMovie_ShouldThrowException_WhenRepositoryIsEmpty()
    {
        // Arrange
        moviesRepository.GetAllMovies().Returns(Enumerable.Empty<Movie>());

        // Act
        var act = () => objUt.GetRandomMovie();

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("No movies found in the repository.");
    }

    #endregion
}
