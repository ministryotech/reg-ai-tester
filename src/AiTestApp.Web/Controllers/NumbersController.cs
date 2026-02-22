using AiTestApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AiTestApp.Web.Controllers;

/// <summary>
/// Controller for number/dice generation.
/// </summary>
public class NumbersController(IDiceService diceService) : Controller
{
    /// <summary>
    /// Displays a page to select a die type.
    /// </summary>
    public IActionResult Index() => View();

    /// <summary>
    /// Displays the result of rolling a specific die.
    /// </summary>
    public IActionResult Roll(string dieType)
    {
        var viewModel = diceService.Roll(dieType);
        return View(viewModel);
    }
}
