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
    private readonly IMoviesService _moviesService = Substitute.For<IMoviesService>();
    private readonly HomeController _sut;

    public HomeControllerTests()
    {
        _sut = new HomeController(_moviesService)
        {
            TempData = new TempDataDictionary(new DefaultHttpContext(), Substitute.For<ITempDataProvider>())
        };
    }

    [Fact]
    public void Index_ShouldReturnView()
    {
        // Act
        var result = _sut.Index();

        // Assert
        result.Should().BeOfType<ViewResult>();
    }

    [Fact]
    public void Privacy_ShouldReturnView()
    {
        // Act
        var result = _sut.Privacy();

        // Assert
        result.Should().BeOfType<ViewResult>();
    }

    [Fact]
    public void Movie_ShouldReturnViewWithModelFromService()
    {
        // Arrange
        var viewModel = new MovieViewModel("Title", "D", "U", "G", 2024);
        _moviesService.GetRandomMovie(Arg.Any<string>()).Returns(viewModel);
        _sut.TempData["LastMovieTitle"] = "OldTitle";

        // Act
        var result = _sut.Movie();

        // Assert
        var viewResult = result.Should().BeOfType<ViewResult>().Subject;
        viewResult.Model.Should().Be(viewModel);
        _sut.TempData["LastMovieTitle"].Should().Be(viewModel.Title);
        _moviesService.Received(1).GetRandomMovie("OldTitle");
    }

    [Fact]
    public void Error_ShouldReturnViewWithModel()
    {
        // Arrange
        _sut.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext()
        };

        // Act
        var result = _sut.Error();

        // Assert
        var viewResult = result.Should().BeOfType<ViewResult>().Subject;
        var model = viewResult.Model.Should().BeOfType<ErrorViewModel>().Subject;
        model.RequestId.Should().NotBeNullOrEmpty();
    }
}
