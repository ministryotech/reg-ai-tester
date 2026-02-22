using AiTestApp.Models;

namespace AiTestApp.Services;

#region | Interface |

/// <summary>
/// Interface for a service that generates random numbers from dice.
/// </summary>
public interface IDiceService
{
    /// <summary>
    /// Generates a random number from the specified die type.
    /// </summary>
    /// <param name="dieType">The type of die (e.g., d4, d20).</param>
    /// <returns>A view model containing the result.</returns>
    NumberViewModel Roll(string dieType);
}

#endregion

/// <summary>
/// Service that generates random numbers from dice.
/// </summary>
public class DiceService : IDiceService
{
    /// <inheritdoc />
    public NumberViewModel Roll(string dieType)
    {
        var sides = dieType.ToLower() switch
        {
            "d4" => 4,
            "d6" => 6,
            "d8" => 8,
            "d10" => 10,
            "d12" => 12,
            "d20" => 20,
            "d100" => 100,
            _ => throw new ArgumentException("Invalid die type", nameof(dieType))
        };

        var random = new Random();
        return new NumberViewModel(dieType, random.Next(1, sides + 1));
    }
}
