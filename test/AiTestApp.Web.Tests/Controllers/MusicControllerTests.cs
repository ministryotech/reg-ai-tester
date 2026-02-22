using AiTestApp.Models;
using AiTestApp.Services;
using AiTestApp.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NSubstitute;

namespace AiTestApp.Web.Tests.Controllers;

public sealed class MusicControllerTests
{
    private readonly IAlbumsService albumsService = Substitute.For<IAlbumsService>();

    #region | TESTS: AlbumPrompt |

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

    #endregion

    #region | TESTS: Index |

    [Fact]
    public void Index_ShouldReturnViewWithModel()
    {
        // Arrange
        var objUt = BuildObjUt();
        var viewModel = new AlbumViewModel("Album", "A", "G", "D", 2024);
        albumsService.GetRandom("G", Arg.Any<string>()).Returns(viewModel);
        objUt.TempData["LastAlbumTitle"] = "Old";

        // Act
        var result = objUt.Index("G");

        // Assert
        var viewResult = result.Should().BeOfType<ViewResult>().Subject;
        viewResult.Model.Should().Be(viewModel);
        objUt.TempData["LastAlbumTitle"].Should().Be("Album");
        albumsService.Received(1).GetRandom("G", "Old");
    }

    #endregion

    #region | Supporting Methods |

    private MusicController BuildObjUt() => new(albumsService)
    {
        TempData = new TempDataDictionary(new DefaultHttpContext(), Substitute.For<ITempDataProvider>())
    };

    #endregion
}
