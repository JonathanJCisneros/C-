using Microsoft.AspNetCore.Mvc;
// Inherit from abstract base controller class
// inherits helpful methods for handling HTTP req/res cycle
public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("/videos")]
    public IActionResult Videos()
    {

        VideosView videoObject = new VideosView();

        return View("Videos", videoObject);
    }

    [HttpGet("/showingModel")]
    public IActionResult ModelDisplay()
    {
        List<int> myNums = new List<int>(){1,2,3};
        MyModel someModel = new MyModel("squirtle", myNums);

        ViewBag.MyModel = someModel;
        return View();
    }
}