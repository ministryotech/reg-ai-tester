using AiTestApp.Repositories.Contracts;
using NSubstitute;
using System.Text.Json;

namespace AiTestApp.Repositories.Tests;

public sealed class TvShowsRepositoryTests
{
    private readonly ITvShowsJsonDataSourceRepository tvShowsDataSource = Substitute.For<ITvShowsJsonDataSourceRepository>();

    #region | TESTS: GetAll |

    [Fact]
    public void GetAll_ShouldReturnItemsFromJson()
    {
        // Arrange
        var objUt = BuildObjUt(tvShowsDataSource);
        var items = new List<TvShow> { new("Show 1", "D", "U", "G", 2024) };
        tvShowsDataSource.ReadRawJson().Returns(JsonSerializer.Serialize(items));

        // Act
        var result = objUt.GetAll();

        // Assert
        result.Should().HaveCount(1);
        result[0].Title.Should().Be("Show 1");
    }

    #endregion

    #region | Supporting Methods |

    private static TvShowsRepository BuildObjUt(ITvShowsJsonDataSourceRepository tvShowsDataSource) => new(tvShowsDataSource);

    #endregion
}
