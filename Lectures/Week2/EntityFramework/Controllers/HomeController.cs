using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkDemo.Models;

namespace EntityFramework.Controllers;

public class HomeController : Controller
{
    public IActionResult Privacy()
    {
        return View();
    }
}
