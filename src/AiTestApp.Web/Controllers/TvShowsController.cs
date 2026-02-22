using AiTestApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AiTestApp.Web.Controllers;

/// <summary>
/// Controller for TV show selection.
/// </summary>
public class TvShowsController(ITvShowsService tvShowsService) : Controller
{
    /// <summary>
    /// Displays a randomly selected TV show.
    /// </summary>
    public IActionResult Index()
    {
        var lastTitle = TempData["LastTvShowTitle"] as string;
        var viewModel = tvShowsService.GetRandom(lastTitle);
        TempData["LastTvShowTitle"] = viewModel.Title;
        return View(viewModel);
    }
}
