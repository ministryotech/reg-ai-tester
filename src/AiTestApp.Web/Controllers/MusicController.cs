using AiTestApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AiTestApp.Web.Controllers;

/// <summary>
/// Controller for album selection.
/// </summary>
public class MusicController(IAlbumsService albumsService) : Controller
{
    /// <summary>
    /// Displays a page to select a genre or random for album selection.
    /// </summary>
    public IActionResult AlbumPrompt() => View();

    /// <summary>
    /// Displays a randomly selected album, optionally filtered by genre.
    /// </summary>
    public IActionResult Index(string? genre = null)
    {
        var lastTitle = TempData["LastAlbumTitle"] as string;
        var viewModel = albumsService.GetRandom(genre, lastTitle);
        TempData["LastAlbumTitle"] = viewModel.Title;
        ViewBag.Genre = genre;
        return View(viewModel);
    }
}
