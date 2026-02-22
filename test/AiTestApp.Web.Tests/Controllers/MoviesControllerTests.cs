using AiTestApp.Models;
using AiTestApp.Services;
using AiTestApp.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NSubstitute;

namespace AiTestApp.Web.Tests.Controllers;

public sealed class MoviesControllerTests
{
    private readonly IMoviesService moviesService = Substitute.For<IMoviesService>();

    #region | TESTS: Index |

    [Fact]
    public void Index_ShouldReturnViewWithModel()
    {
        // Arrange
        var objUt = BuildObjUt();
        var viewModel = new MovieViewModel("Movie", "D", "U", "G", 2024);
        moviesService.GetRandomMovie(Arg.Any<string>()).Returns(viewModel);
        objUt.TempData["LastMovieTitle"] = "Old";

        // Act
        var result = objUt.Index();

        // Assert
        var viewResult = result.Should().BeOfType<ViewResult>().Subject;
        viewResult.Model.Should().Be(viewModel);
        objUt.TempData["LastMovieTitle"].Should().Be("Movie");
        moviesService.Received(1).GetRandomMovie("Old");
    }

    #endregion

    #region | Supporting Methods |

    private MoviesController BuildObjUt() => new(moviesService)
    {
        TempData = new TempDataDictionary(new DefaultHttpContext(), Substitute.For<ITempDataProvider>())
    };

    #endregion
}
