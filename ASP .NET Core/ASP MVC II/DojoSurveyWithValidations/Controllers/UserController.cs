using Microsoft.AspNetCore.Mvc;

namespace DojoSurveyWithValidations.Models;

public class UserController : Controller
{
    [HttpGet("")]
    public ViewResult Form()
    {
        return View("Register");
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("SubmittedInfo", newUser);
        }
        else
        {
            return View("Register");
        }
    }

    [HttpGet("/result")]
    public ViewResult SubmittedInfo(User newUser)
    {
        return View("Result", newUser);
    }
}