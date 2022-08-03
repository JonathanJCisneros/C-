using Microsoft.AspNetCore.Mvc;

public class Time : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        DateTime CurrentTime = DateTime.Now;
        ViewBag.Time = CurrentTime;
        return View("Index");
    }
}