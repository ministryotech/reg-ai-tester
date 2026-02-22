namespace AiTestApp.Repositories.Tests;

public sealed class AlbumsJsonDataSourceRepositoryTests
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
        result.Should().Contain("The Dark Side of the Moon");
    }

    #endregion

    #region | Supporting Methods |

    private static AlbumsJsonDataSourceRepository BuildObjUt() => new();

    #endregion
}
