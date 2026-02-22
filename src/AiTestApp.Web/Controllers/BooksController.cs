using AiTestApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AiTestApp.Web.Controllers;

/// <summary>
/// Controller for book selection.
/// </summary>
public class BooksController(IBooksService booksService) : Controller
{
    /// <summary>
    /// Displays a page to select a genre for random book selection.
    /// </summary>
    public IActionResult GenreSelection() => View();

    /// <summary>
    /// Displays a randomly selected book for the given genre.
    /// </summary>
    public IActionResult Index(string genre)
    {
        var lastTitle = TempData["LastBookTitle"] as string;
        var viewModel = booksService.GetRandom(genre, lastTitle);
        TempData["LastBookTitle"] = viewModel.Title;
        ViewBag.Genre = genre;
        return View(viewModel);
    }
}
