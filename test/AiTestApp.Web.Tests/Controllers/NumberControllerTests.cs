using AiTestApp.Models;
using AiTestApp.Services;
using AiTestApp.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NSubstitute;

namespace AiTestApp.Web.Tests.Controllers;

public sealed class NumberControllerTests
{
    private readonly IDiceService diceService = Substitute.For<IDiceService>();

    #region | TESTS: Index |

    [Fact]
    public void Index_ShouldReturnView()
    {
        // Arrange
        var objUt = BuildObjUt();

        // Act
        var result = objUt.Index();

        // Assert
        result.Should().BeOfType<ViewResult>();
    }

    #endregion

    #region | TESTS: Roll |

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

    private NumberController BuildObjUt() => new(diceService)
    {
        TempData = new TempDataDictionary(new DefaultHttpContext(), Substitute.For<ITempDataProvider>())
    };

    #endregion
}
