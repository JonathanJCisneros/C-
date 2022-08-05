using Microsoft.AspNetCore.Mvc;
using SessionAndValidation.Models;
namespace SessionAndValidation.Controllers;

using Microsoft.AspNetCore.Http;

public class UserController : Controller
{
    [HttpGet("/login")]
    public IActionResult Login()
    {
        List<int> someInts = new List<int>(){ 1, 2, 3 };
        ViewBag.ints = someInts;
        return View("Login");
    }

    [HttpGet("/success")]
    public IActionResult Success()
    {
        return View("Success");
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("username", newUser.Username);
            return RedirectToAction("StoryTime", "Home");
        }

        return Login();
    }

    [HttpGet("/logout")]
    public IActionResult Logout()
    {

        HttpContext.Session.Remove("username");

        //this clears everything
        // HttpContext.Session.Clear();

        return RedirectToAction("Index", "Home");
    }
}