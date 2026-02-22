namespace AiTestApp.Models;

/// <summary>
/// View model used by the UI to display a generated number.
/// </summary>
/// <param name="DieType">Gets the type of die used (e.g., d20).</param>
/// <param name="Result">Gets the randomly generated number.</param>
public record NumberViewModel(string DieType, int Result);
