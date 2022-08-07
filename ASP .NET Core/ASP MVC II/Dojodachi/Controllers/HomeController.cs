using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojodachiGame.Models;

namespace DojodachiGame.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

}
