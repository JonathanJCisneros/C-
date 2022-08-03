using Microsoft.AspNetCore.Mvc;

public class Home : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }
}