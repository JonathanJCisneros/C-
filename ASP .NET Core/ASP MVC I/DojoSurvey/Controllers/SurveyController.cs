using Microsoft.AspNetCore.Mvc;

public class Survey : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpPost("/result")]
    public IActionResult Method(string name, string location, string faveLang, string comment)
    {
        ViewBag.Name = name; 
        ViewBag.Location = location;
        ViewBag.FaveLang = faveLang;
        ViewBag.Comment = comment;
        return View("Result");
    }
}