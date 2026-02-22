using Microsoft.AspNetCore.Mvc;
using AiTestApp.Services;
using AiTestApp.Models;

namespace AiTestApp.Web.Controllers;

/// <summary>
/// Controller for additional random item selection pages.
/// </summary>
public class GeneratorController(
    ITvShowsService tvShowsService,
    IBooksService booksService,
    IAlbumsService albumsService,
    IDiceService diceService) : Controller
{
    #region | TV Shows |

    /// <summary>
    /// Displays a randomly selected TV show.
    /// </summary>
    public IActionResult TvShow()
    {
        var lastTitle = TempData["LastTvShowTitle"] as string;
        var viewModel = tvShowsService.GetRandom(lastTitle);
        TempData["LastTvShowTitle"] = viewModel.Title;
        return View(viewModel);
    }

    #endregion

    #region | Books |

    /// <summary>
    /// Displays a page to select a genre for random book selection.
    /// </summary>
    public IActionResult BookGenre() => View();

    /// <summary>
    /// Displays a randomly selected book for the given genre.
    /// </summary>
    public IActionResult Book(string genre)
    {
        var lastTitle = TempData["LastBookTitle"] as string;
        var viewModel = booksService.GetRandom(genre, lastTitle);
        TempData["LastBookTitle"] = viewModel.Title;
        ViewBag.Genre = genre;
        return View(viewModel);
    }

    #endregion

    #region | Albums |

    /// <summary>
    /// Displays a page to select a genre or random for album selection.
    /// </summary>
    public IActionResult AlbumPrompt() => View();

    /// <summary>
    /// Displays a randomly selected album, optionally filtered by genre.
    /// </summary>
    public IActionResult Album(string? genre = null)
    {
        var lastTitle = TempData["LastAlbumTitle"] as string;
        var viewModel = albumsService.GetRandom(genre, lastTitle);
        TempData["LastAlbumTitle"] = viewModel.Title;
        ViewBag.Genre = genre;
        return View(viewModel);
    }

    #endregion

    #region | Dice |

    /// <summary>
    /// Displays a page to select a die type.
    /// </summary>
    public IActionResult Dice() => View();

    /// <summary>
    /// Displays the result of rolling a specific die.
    /// </summary>
    public IActionResult Roll(string dieType)
    {
        var viewModel = diceService.Roll(dieType);
        return View(viewModel);
    }

    #endregion
}
