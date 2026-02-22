using AiTestApp.ModelBuilders;
using AiTestApp.Models;
using AiTestApp.Repositories.Contracts;

namespace AiTestApp.Tests.ModelBuilders;

public sealed class ViewModelBuilderTests
{
    #region | TESTS: Build TvShow |

    [Fact]
    public void Build_TvShow_ShouldMapAllPropertiesCorrectly()
    {
        // Arrange
        var objUt = BuildObjUt();
        var show = new TvShow("Show", "Desc", "Url", "Genre", 2024);

        // Act
        var result = objUt.Build(show);

        // Assert
        result.Title.Should().Be(show.Title);
        result.Description.Should().Be(show.Description);
        result.PosterUrl.Should().Be(show.PosterUrl);
        result.Genre.Should().Be(show.Genre);
        result.Year.Should().Be(show.Year);
    }

    #endregion

    #region | TESTS: Build Book |

    [Fact]
    public void Build_Book_ShouldMapAllPropertiesCorrectly()
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

    #endregion

    #region | TESTS: Build Album |

    [Fact]
    public void Build_Album_ShouldMapAllPropertiesCorrectly()
    {
        // Arrange
        var objUt = BuildObjUt();
        var album = new Album("Album", "Artist", "Genre", "Desc", 2024);

        // Act
        var result = objUt.Build(album);

        // Assert
        result.Title.Should().Be(album.Title);
        result.Artist.Should().Be(album.Artist);
        result.Genre.Should().Be(album.Genre);
        result.Description.Should().Be(album.Description);
        result.Year.Should().Be(album.Year);
    }

    #endregion

    #region | Supporting Methods |

    private static ViewModelBuilder BuildObjUt() => new();

    #endregion
}
