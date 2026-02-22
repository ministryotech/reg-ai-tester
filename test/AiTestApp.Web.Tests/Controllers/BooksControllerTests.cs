using AiTestApp.Models;
using AiTestApp.Services;
using AiTestApp.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NSubstitute;

namespace AiTestApp.Web.Tests.Controllers;

public sealed class BooksControllerTests
{
    private readonly IBooksService booksService = Substitute.For<IBooksService>();

    #region | TESTS: GenreSelection |

    [Fact]
    public void GenreSelection_ShouldReturnView()
    {
        // Arrange
        var objUt = BuildObjUt();

        // Act
        var result = objUt.GenreSelection();

        // Assert
        result.Should().BeOfType<ViewResult>();
    }

    #endregion

    #region | TESTS: Index |

    [Fact]
    public void Index_ShouldReturnViewWithModel()
    {
        // Arrange
        var objUt = BuildObjUt();
        var viewModel = new BookViewModel("Book", "A", "G", "D", 2024);
        booksService.GetRandom("G", Arg.Any<string>()).Returns(viewModel);
        objUt.TempData["LastBookTitle"] = "Old";

        // Act
        var result = objUt.Index("G");

        // Assert
        var viewResult = result.Should().BeOfType<ViewResult>().Subject;
        viewResult.Model.Should().Be(viewModel);
        objUt.TempData["LastBookTitle"].Should().Be("Book");
        booksService.Received(1).GetRandom("G", "Old");
    }

    #endregion

    #region | Supporting Methods |

    private BooksController BuildObjUt() => new(booksService)
    {
        TempData = new TempDataDictionary(new DefaultHttpContext(), Substitute.For<ITempDataProvider>())
    };

    #endregion
}
