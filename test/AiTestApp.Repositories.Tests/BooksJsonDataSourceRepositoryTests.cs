namespace AiTestApp.Repositories.Tests;

public sealed class BooksJsonDataSourceRepositoryTests
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
        result.Should().Contain("Dune");
    }

    #endregion

    #region | Supporting Methods |

    private static BooksJsonDataSourceRepository BuildObjUt() => new();

    #endregion
}
