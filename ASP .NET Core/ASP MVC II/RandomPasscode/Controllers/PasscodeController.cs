using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;

public class PasscodeController : Controller
{
    [HttpGet("/")]
    public IActionResult Generate()
    {
        int? Count = HttpContext.Session.GetInt32("amount");
        if(Count == null) HttpContext.Session.SetInt32("amount", 1);
        Passcode newPasscode = new Passcode();
        return View("Random", newPasscode);
    }

    [HttpPost("/addCount")]
    public IActionResult AddCount()
    {
        int? PassCount = HttpContext.Session.GetInt32("amount");

        if (PassCount == null)
        {
            PassCount = 1;
        }
        else
        {
            PassCount += 1;
        }

        HttpContext.Session.SetInt32("amount", (int)PassCount);
        return RedirectToAction("Generate");
    }
}

