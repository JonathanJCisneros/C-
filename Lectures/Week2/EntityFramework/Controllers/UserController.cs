using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkDemo.Models;
namespace EntityFrameworkDemo.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

public class UserController : Controller
{
    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UUID");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }
    private EFLectureContext db;

    public UserController(EFLectureContext context)
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
        return View("Index");
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            if(db.Users.Any(user => user.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "is taken");
            }
        }

        if(ModelState.IsValid == false)
        {
            return Index();
        }

        PasswordHasher<User> hashBrowns = new PasswordHasher<User>();
        newUser.Password = hashBrowns.HashPassword(newUser, newUser.Password);
        
        db.Users.Add(newUser);
        db.SaveChanges();
        HttpContext.Session.SetInt32("UUID", newUser.UserId);
        HttpContext.Session.SetString("name", newUser.FullName());
        return RedirectToAction("All", "Post");
    }

    [HttpPost("/login")]
    public IActionResult Login(LoginUser user)
    {
        if(ModelState.IsValid == false)
        {
            return Index();
        }
        
        User? dbUser = db.Users.FirstOrDefault(User => User.Email == user.LoginEmail);

        if(dbUser == null)
        {
            ModelState.AddModelError("LoginEmail", "not found");
            return Index();
        }

        PasswordHasher<LoginUser> hashBrowns = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCheck = hashBrowns.VerifyHashedPassword(user, dbUser.Password, user.LoginPassword);

        if(pwCheck == 0)
        {
            ModelState.AddModelError("LoginPassword", "is not correct");
            return Index();
        }

        HttpContext.Session.SetInt32("UUID", dbUser.UserId);
        HttpContext.Session.SetString("name", dbUser.FullName());
        return RedirectToAction("All", "Post");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}