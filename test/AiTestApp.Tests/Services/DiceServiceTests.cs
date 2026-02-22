using AiTestApp.Services;

namespace AiTestApp.Tests.Services;

public sealed class DiceServiceTests
{
    #region | TESTS: Roll |

    [Theory]
    [InlineData("d4", 1, 4)]
    [InlineData("d6", 1, 6)]
    [InlineData("d8", 1, 8)]
    [InlineData("d10", 1, 10)]
    [InlineData("d12", 1, 12)]
    [InlineData("d20", 1, 20)]
    [InlineData("d100", 1, 100)]
    public void Roll_ShouldReturnNumberInRange(string dieType, int min, int max)
    {
        // Arrange
        var objUt = BuildObjUt();

        // Act
        var result = objUt.Roll(dieType);

        // Assert
        result.DieType.Should().Be(dieType);
        result.Result.Should().BeInRange(min, max);
    }

    [Fact]
    public void Roll_ShouldThrowException_WhenDieTypeIsInvalid()
    {
        // Arrange
        var objUt = BuildObjUt();

        // Act
        var act = () => objUt.Roll("d7");

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage("Invalid die type*");
    }

    #endregion

    #region | Supporting Methods |

    private static IDiceService BuildObjUt() => new DiceService();

    #endregion
}
