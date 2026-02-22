using AiTestApp.Models;
using AiTestApp.Services;
using AiTestApp.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NSubstitute;

namespace AiTestApp.Web.Tests.Controllers;

public sealed class GeneratorControllerTests
{
    private readonly ITvShowsService tvShowsService = Substitute.For<ITvShowsService>();
    private readonly IBooksService booksService = Substitute.For<IBooksService>();
    private readonly IAlbumsService albumsService = Substitute.For<IAlbumsService>();
    private readonly IDiceService diceService = Substitute.For<IDiceService>();

    #region | TESTS: TvShow |

    [Fact]
    public void TvShow_ShouldReturnViewWithModel()
    {
        // Arrange
        var objUt = BuildObjUt();
        var viewModel = new TvShowViewModel("Show", "D", "U", "G", 2024);
        tvShowsService.GetRandom(Arg.Any<string>()).Returns(viewModel);
        objUt.TempData["LastTvShowTitle"] = "Old";

        // Act
        var result = objUt.TvShow();

        // Assert
        var viewResult = result.Should().BeOfType<ViewResult>().Subject;
        viewResult.Model.Should().Be(viewModel);
        objUt.TempData["LastTvShowTitle"].Should().Be("Show");
        tvShowsService.Received(1).GetRandom("Old");
    }

    #endregion

    #region | TESTS: Books |

    [Fact]
    public void BookGenre_ShouldReturnView()
    {
        // Arrange
        var objUt = BuildObjUt();

        // Act
        var result = objUt.BookGenre();

        // Assert
        result.Should().BeOfType<ViewResult>();
    }

    [Fact]
    public void Book_ShouldReturnViewWithModel()
    {
        // Arrange
        var objUt = BuildObjUt();
        var viewModel = new BookViewModel("Book", "A", "G", "D", 2024);
        booksService.GetRandom("G", Arg.Any<string>()).Returns(viewModel);
        objUt.TempData["LastBookTitle"] = "Old";

        // Act
        var result = objUt.Book("G");

        // Assert
        var viewResult = result.Should().BeOfType<ViewResult>().Subject;
        viewResult.Model.Should().Be(viewModel);
        objUt.TempData["LastBookTitle"].Should().Be("Book");
        booksService.Received(1).GetRandom("G", "Old");
    }

    #endregion

    #region | TESTS: Albums |

    [Fact]
    public void AlbumPrompt_ShouldReturnView()
    {
        // Arrange
        var objUt = BuildObjUt();

        // Act
        var result = objUt.AlbumPrompt();

        // Assert
        result.Should().BeOfType<ViewResult>();
    }

    [Fact]
    public void Album_ShouldReturnViewWithModel()
    {
        // Arrange
        var objUt = BuildObjUt();
        var viewModel = new AlbumViewModel("Album", "A", "G", "D", 2024);
        albumsService.GetRandom("G", Arg.Any<string>()).Returns(viewModel);
        objUt.TempData["LastAlbumTitle"] = "Old";

        // Act
        var result = objUt.Album("G");

        // Assert
        var viewResult = result.Should().BeOfType<ViewResult>().Subject;
        viewResult.Model.Should().Be(viewModel);
        objUt.TempData["LastAlbumTitle"].Should().Be("Album");
        albumsService.Received(1).GetRandom("G", "Old");
    }

    #endregion

    #region | TESTS: Dice |

    [Fact]
    public void Dice_ShouldReturnView()
    {
        // Arrange
        var objUt = BuildObjUt();

        // Act
        var result = objUt.Dice();

        // Assert
        result.Should().BeOfType<ViewResult>();
    }

    [Fact]
    public void Roll_ShouldReturnViewWithModel()
    {
        // Arrange
        var objUt = BuildObjUt();
        var viewModel = new NumberViewModel("d20", 15);
        diceService.Roll("d20").Returns(viewModel);

        // Act
        var result = objUt.Roll("d20");

        // Assert
        var viewResult = result.Should().BeOfType<ViewResult>().Subject;
        viewResult.Model.Should().Be(viewModel);
        diceService.Received(1).Roll("d20");
    }

    #endregion

    #region | Supporting Methods |

    private GeneratorController BuildObjUt() => new(tvShowsService, booksService, albumsService, diceService)
    {
        TempData = new TempDataDictionary(new DefaultHttpContext(), Substitute.For<ITempDataProvider>())
    };

    #endregion
}
