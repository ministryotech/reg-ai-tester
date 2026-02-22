namespace AiTestApp.Models;

/// <summary>
/// View model representing error information to be displayed to the user.
/// </summary>
/// <param name="RequestId">Gets or sets the unique request identifier associated with the current request.</param>
public record ErrorViewModel(string? RequestId)
{
    /// <summary>
    /// Gets a value indicating whether the <see cref="RequestId"/> should be displayed.
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
