using AiTestApp.Models;
using AiTestApp.Services;
using AiTestApp.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NSubstitute;

namespace AiTestApp.Web.Tests.Controllers;

public class HomeControllerTests
{
    private readonly IMoviesService moviesService = Substitute.For<IMoviesService>();
    private readonly HomeController objUt;

    public HomeControllerTests()
    {
        objUt = new HomeController(moviesService)
        {
            TempData = new TempDataDictionary(new DefaultHttpContext(), Substitute.For<ITempDataProvider>())
        };
    }

    #region | TESTS: Index |

    [Fact]
    public void Index_ShouldReturnView()
    {
        // Act
        var result = objUt.Index();

        // Assert
        result.Should().BeOfType<ViewResult>();
    }

    #endregion

    #region | TESTS: Privacy |

    [Fact]
    public void Privacy_ShouldReturnView()
    {
        // Act
        var result = objUt.Privacy();

        // Assert
        result.Should().BeOfType<ViewResult>();
    }

    #endregion

    #region | TESTS: Movie |

    [Fact]
    public void Movie_ShouldReturnViewWithModelFromService()
    {
        // Arrange
        var viewModel = new MovieViewModel("Title", "D", "U", "G", 2024);
        moviesService.GetRandomMovie(Arg.Any<string>()).Returns(viewModel);
        objUt.TempData["LastMovieTitle"] = "OldTitle";

        // Act
        var result = objUt.Movie();

        // Assert
        var viewResult = result.Should().BeOfType<ViewResult>().Subject;
        viewResult.Model.Should().Be(viewModel);
        objUt.TempData["LastMovieTitle"].Should().Be(viewModel.Title);
        moviesService.Received(1).GetRandomMovie("OldTitle");
    }

    #endregion

    #region | TESTS: Error |

    [Fact]
    public void Error_ShouldReturnViewWithModel()
    {
        // Arrange
        objUt.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = objUt.Error();

        // Assert
        var viewResult = result.Should().BeOfType<ViewResult>().Subject;
        var model = viewResult.Model.Should().BeOfType<ErrorViewModel>().Subject;
        model.RequestId.Should().NotBeNullOrEmpty();
    }

    #endregion
}
