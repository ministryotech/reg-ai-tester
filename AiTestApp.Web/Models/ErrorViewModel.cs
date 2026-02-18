namespace AiTestApp.Models;

/// <summary>
/// View model representing error information to be displayed to the user.
/// </summary>
public class ErrorViewModel
{
    /// <summary>
    /// Gets or sets the unique request identifier associated with the current request.
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// Gets a value indicating whether the <see cref="RequestId"/> should be displayed.
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}