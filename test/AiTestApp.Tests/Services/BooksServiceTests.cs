using AiTestApp.Repositories;
using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;
using AiTestApp.Services;
using NSubstitute;

namespace AiTestApp.Tests.Services;

public sealed class BooksServiceTests
{
    private readonly IBooksRepository booksRepository = Substitute.For<IBooksRepository>();
    private readonly IBookModelBuilder bookBuilder = Substitute.For<IBookModelBuilder>();

    #region | TESTS: GetRandom |

    [Fact]
    public void GetRandom_ShouldReturnBookOfGenre()
    {
        // Arrange
        var objUt = BuildObjUt();
        var books = new List<Book>
        {
            new("Book 1", "A", "Genre A", "D", 2024),
            new("Book 2", "A", "Genre B", "D", 2024)
        };
        booksRepository.GetAll().Returns(books);
        var viewModel = new BookViewModel("Book 1", "A", "Genre A", "D", 2024);
        bookBuilder.Build(books[0]).Returns(viewModel);

        // Act
        var result = objUt.GetRandom("Genre A");

        // Assert
        result.Title.Should().Be("Book 1");
        result.Genre.Should().Be("Genre A");
    }

    [Fact]
    public void GetRandom_ShouldThrowException_WhenNoBooksInGenre()
    {
        // Arrange
        var objUt = BuildObjUt();
        var books = new List<Book> { new("Book 1", "A", "Genre A", "D", 2024) };
        booksRepository.GetAll().Returns(books);

        // Act
        var act = () => objUt.GetRandom("Genre B");

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("No books found for genre: Genre B");
    }

    #endregion

    #region | Supporting Methods |

    private IBooksService BuildObjUt() =>
        new BooksService(booksRepository, bookBuilder);

    #endregion
}
