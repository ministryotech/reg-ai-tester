using AiTestApp.Models;
using AiTestApp.Services;
using AiTestApp.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NSubstitute;

namespace AiTestApp.Web.Tests.Controllers;

public sealed class TvShowsControllerTests
{
    private readonly ITvShowsService tvShowsService = Substitute.For<ITvShowsService>();

    #region | TESTS: Index |

    [Fact]
    public void Index_ShouldReturnViewWithModel()
    {
        // Arrange
        var objUt = BuildObjUt();
        var viewModel = new TvShowViewModel("Show", "D", "U", "G", 2024);
        tvShowsService.GetRandom(Arg.Any<string>()).Returns(viewModel);
        objUt.TempData["LastTvShowTitle"] = "Old";

        // Act
        var result = objUt.Index();

        // Assert
        var viewResult = result.Should().BeOfType<ViewResult>().Subject;
        viewResult.Model.Should().Be(viewModel);
        objUt.TempData["LastTvShowTitle"].Should().Be("Show");
        tvShowsService.Received(1).GetRandom("Old");
    }

    #endregion

    #region | Supporting Methods |

    private TvShowsController BuildObjUt() => new(tvShowsService)
    {
        TempData = new TempDataDictionary(new DefaultHttpContext(), Substitute.For<ITempDataProvider>())
    };

    #endregion
}
