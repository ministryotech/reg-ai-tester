using AiTestApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AiTestApp.Web.Controllers;

/// <summary>
/// Controller for movie selection.
/// </summary>
/// <param name="moviesService">Service used to manage movie operations.</param>
public class MoviesController(IMoviesService moviesService) : Controller
{
    /// <summary>
    /// Displays a page with a randomly selected movie.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Controller.TempData"/> to avoid returning the same movie twice in a row.
    /// </remarks>
    /// <returns>The movie view populated with a <see cref="MovieViewModel"/>.</returns>
    public IActionResult Index()
    {
        var lastTitle = TempData["LastMovieTitle"] as string;
        var viewModel = moviesService.GetRandomMovie(lastTitle);
        TempData["LastMovieTitle"] = viewModel.Title;

        return View(viewModel);
    }
}
