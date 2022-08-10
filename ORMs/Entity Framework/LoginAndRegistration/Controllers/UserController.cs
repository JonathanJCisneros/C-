using Microsoft.AspNetCore.Mvc;
using LoginAndRegistration.Models;
namespace EntityFramework.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

public class UserController : Controller
{
    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("userId");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }

    private LogRegContext db;

    public UserController(LogRegContext context)
    {
        db = context;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        if(loggedIn)
        {
            return RedirectToAction("All", "Post");
        }
        return View("Register");
    }
}