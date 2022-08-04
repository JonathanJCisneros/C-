using Microsoft.AspNetCore.Mvc;

namespace DojoSurveyModel.Models;

public class SurveyController : Controller
{
    [HttpGet("/")]
    public IActionResult Form()
    {
        return View("Form");
    }

    [HttpPost("/survey")]
    public IActionResult Submission(Survey yourSurvey)
    {
        return View("Result", yourSurvey);
    }
}
