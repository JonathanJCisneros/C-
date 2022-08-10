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
            return Success();
        }
        return View("Register");
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
        HttpContext.Session.SetInt32("userId", newUser.UserId);
        return Success();
    }


    [HttpGet("/login")]
    public IActionResult Enter()
    {
        if(loggedIn)
        {
            return Success();
        }
        return View("Login");
    }


    [HttpPost("/loggingin")]
    public IActionResult Login(LoginUser user)
    {
        if(ModelState.IsValid == false)
        {
            return Enter();
        }

        User? dbUser = db.Users.FirstOrDefault(User => User.Email == user.LoginEmail);

        if(dbUser == null)
        {
            ModelState.AddModelError("LoginEmail", "not found");
            return Enter();
        }

        PasswordHasher<LoginUser> hashBrowns = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCheck = hashBrowns.VerifyHashedPassword(user, dbUser.Password, user.LoginPassword);

        if(pwCheck == 0)
        {
            ModelState.AddModelError("LoginPassword", "is not correct");
            return Enter();
        }

        HttpContext.Session.SetInt32("userId", dbUser.UserId);
        return Success();
    }


    [HttpGet("/success")]
    public IActionResult Success()
    {
        if(!loggedIn)
        {
            return Enter();
        }
        return View("Success");
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Enter();
    }
}