namespace AiTestApp.Repositories.Tests;

public sealed class MoviesJsonDataSourceRepositoryTests
{
    #region | TESTS: ReadRawJson |

    [Fact]
    public void ReadRawJson_ShouldReturnContentFromFile()
    {
        // Arrange
        var objUt = BuildObjUt();

        // Act
        var result = objUt.ReadRawJson();

        // Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Contain("Dune: Part Two");
        result.Should().Contain("Gladiator II");
    }

    #endregion

    #region | Supporting Methods |

    private static MoviesJsonDataSourceRepository BuildObjUt() => new();

    #endregion
}
