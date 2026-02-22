namespace AiTestApp.Repositories.Tests;

public sealed class TvShowsJsonDataSourceRepositoryTests
{
    #region | TESTS: ReadRawJson |

    [Fact]
    public void ReadRawJson_ShouldReturnContent()
    {
        // Arrange
        var objUt = BuildObjUt();

        // Act
        var result = objUt.ReadRawJson();

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Contain("The Expanse");
    }

    #endregion

    #region | Supporting Methods |

    private static TvShowsJsonDataSourceRepository BuildObjUt() => new();

    #endregion
}
