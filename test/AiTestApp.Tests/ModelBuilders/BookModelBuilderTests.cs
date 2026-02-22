using AiTestApp.ModelBuilders;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Tests.ModelBuilders;

public sealed class BookModelBuilderTests
{
    #region | TESTS: Build |

    [Fact]
    public void Build_ShouldMapAllPropertiesCorrectly()
    {
        // Arrange
        var objUt = BuildObjUt();
        var book = new Book("Book", "Author", "Genre", "Desc", 2024);

        // Act
        var result = objUt.Build(book);

        // Assert
        result.Title.Should().Be(book.Title);
        result.Author.Should().Be(book.Author);
        result.Genre.Should().Be(book.Genre);
        result.Description.Should().Be(book.Description);
        result.Year.Should().Be(book.Year);
    }

    [Fact]
    public void Build_ShouldThrowArgumentNullException_WhenBookIsNull()
    {
        // Arrange
        var objUt = BuildObjUt();

        // Act
        var act = () => objUt.Build(null!);

        // Assert
        act.Should().Throw<ArgumentNullException>().WithParameterName("book");
    }

    #endregion

    #region | Supporting Methods |

    private static BookModelBuilder BuildObjUt() => new();

    #endregion
}
