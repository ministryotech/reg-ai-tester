using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AiTestApp.Models;
using AiTestApp.Services;

namespace AiTestApp.Web.Controllers;

/// <summary>
/// Handles routes for the home area of the site, including index, privacy, and movie pages.
/// </summary>
/// <param name="moviesService">Service used to manage movie operations.</param>
public class HomeController(IMoviesService moviesService) : Controller
{
    /// <summary>
    /// Displays the home page.
    /// </summary>
    /// <returns>The index view.</returns>
    public IActionResult Index()
    {
        return View();
    }

    /// <summary>
    /// Displays a page with a randomly selected movie.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="TempData"/> to avoid returning the same movie twice in a row.
    /// </remarks>
    /// <returns>The movie view populated with a <see cref="MovieViewModel"/>.</returns>
    public IActionResult Movie()
    {
        var lastTitle = TempData["LastMovieTitle"] as string;
        var viewModel = moviesService.GetRandomMovie(lastTitle);
        TempData["LastMovieTitle"] = viewModel.Title;

        return View(viewModel);
    }

    /// <summary>
    /// Displays the privacy policy page.
    /// </summary>
    /// <returns>The privacy view.</returns>
    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    /// Displays the error page with diagnostic information.
    /// </summary>
    /// <returns>The error view populated with <see cref="ErrorViewModel"/>.</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}