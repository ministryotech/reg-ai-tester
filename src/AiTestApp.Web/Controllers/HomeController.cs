using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AiTestApp.Models;
using AiTestApp.Services;

namespace AiTestApp.Web.Controllers;

/// <summary>
/// Handles routes for the home area of the site, including index and privacy pages.
/// </summary>
public class HomeController() : Controller
{
    /// <summary>
    /// Displays the home page.
    /// </summary>
    /// <returns>The index view.</returns>
    public IActionResult Index() => View();

    /// <summary>
    /// Displays the privacy policy page.
    /// </summary>
    /// <returns>The privacy view.</returns>
    public IActionResult Privacy() => View();

    /// <summary>
    /// Displays the error page with diagnostic information.
    /// </summary>
    /// <returns>The error view populated with <see cref="ErrorViewModel"/>.</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() => View(new ErrorViewModel(Activity.Current?.Id ?? HttpContext.TraceIdentifier));
}
