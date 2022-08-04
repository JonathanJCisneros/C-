using Microsoft.AspNetCore.Mvc;

namespace ValidatingFormSubmission.Models;

public class UserController : Controller
{
    [HttpGet("/")]
    public ViewResult Form()
    {
        return View("Form");
    }

    [HttpPost("/")]
    public IActionResult Submission(User newUser)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("Success", newUser);
        }
        else
        {
            return View("Form");
        }
    }

    [HttpGet("/success")]
    public ViewResult Success(User newUser)
    {
        return View("Success", newUser);
    }
}