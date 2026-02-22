using AiTestApp.Repositories.Contracts;
using NSubstitute;
using System.Text.Json;

namespace AiTestApp.Repositories.Tests;

public sealed class BooksRepositoryTests
{
    private readonly IBooksJsonDataSourceRepository booksDataSource = Substitute.For<IBooksJsonDataSourceRepository>();

    #region | TESTS: GetAll |

    [Fact]
    public void GetAll_ShouldReturnItemsFromJson()
    {
        // Arrange
        var objUt = BuildObjUt(booksDataSource);
        var items = new List<Book> { new("Book 1", "A", "G", "D", 2024) };
        booksDataSource.ReadRawJson().Returns(JsonSerializer.Serialize(items));

        // Act
        var result = objUt.GetAll();

        // Assert
        result.Should().HaveCount(1);
        result[0].Title.Should().Be("Book 1");
    }

    #endregion

    #region | Supporting Methods |

    private static BooksRepository BuildObjUt(IBooksJsonDataSourceRepository booksDataSource) => new(booksDataSource);

    #endregion
}
