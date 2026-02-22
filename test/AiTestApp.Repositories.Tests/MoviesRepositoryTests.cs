using AiTestApp.Repositories.Contracts;
using NSubstitute;

namespace AiTestApp.Repositories.Tests;

public sealed class MoviesRepositoryTests
{
    private readonly IJsonDataSourceRepository jsonDataSource = Substitute.For<IJsonDataSourceRepository>();

    #region | TESTS: GetAllMovies |

    [Fact]
    public void GetAllMovies_ShouldReturnMoviesFromJson()
    {
        // Arrange
        var objUt = BuildObjUt(jsonDataSource);
        var json = "[{\"Title\": \"Movie 1\", \"Description\": \"D1\", \"PosterUrl\": \"U1\", \"Genre\": \"G1\", \"Year\": 2021}]";
        jsonDataSource.ReadRawJson().Returns(json);

        // Act
        var result = objUt.GetAllMovies().ToList();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result.First().Title.Should().Be("Movie 1");
    }

    #endregion

    #region | Supporting Methods |

    private static MoviesRepository BuildObjUt(IJsonDataSourceRepository jsonDataSource) => new(jsonDataSource);

    #endregion
}
