using NSubstitute;

namespace AiTestApp.Repositories.Tests;

public sealed class MoviesRepositoryTests
{
    private readonly IMoviesJsonDataSourceRepository jsonDataSource = Substitute.For<IMoviesJsonDataSourceRepository>();

    #region | TESTS: GetAllMovies |

    [Fact]
    public void GetAllMovies_ShouldReturnMoviesFromJson()
    {
        // Arrange
        var objUt = BuildObjUt();
        var json = "[{\"Title\": \"Movie 1\", \"Description\": \"D1\", \"PosterUrl\": \"U1\", \"Genre\": \"G1\", \"Year\": 2021}]";
        jsonDataSource.ReadRawJson().Returns(json);

        // Act
        var result = objUt.GetAllMovies();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result[0].Title.Should().Be("Movie 1");
    }

    #endregion

    #region | Supporting Methods |

    private MoviesRepository BuildObjUt() => new(jsonDataSource);

    #endregion
}
