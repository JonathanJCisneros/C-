using Microsoft.AspNetCore.Mvc;
using UserDashboard.Models;
namespace UserDashboard.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class UserController : Controller
{
    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UserId");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }
    private UserDashboardContext db;

    public UserController(UserDashboardContext context)
    {
        db = context;
    }

    [HttpGet("/signin")]
    public IActionResult SignIn()
    {
        return View("Login");
    }

    [HttpPost("/login")]
    public IActionResult Login(UserLogin user)
    {
        if(ModelState.IsValid == false)
        {
            return SignIn();
        }

        User? dbUser = db.Users.FirstOrDefault(u => u.Email == user.LoginEmail);

        if(dbUser == null)
        {
            ModelState.AddModelError("LoginEmail", "not found");
            return SignIn();
        } 

        PasswordHasher<UserLogin> hashBrowns = new PasswordHasher<UserLogin>();
        PasswordVerificationResult pwCheck = hashBrowns.VerifyHashedPassword(user, dbUser.Password, user.LoginPassword);

        if(pwCheck == 0)
        {
            ModelState.AddModelError("LoginPassword", "is invalid");
            return SignIn();
        }

        HttpContext.Session.SetInt32("UserId", dbUser.UserId);
        HttpContext.Session.SetString("UserLevel", dbUser.UserLevel);
        return RedirectToAction("Dashboard");
    }

    [HttpGet("/register")]
    public IActionResult NewUser()
    {
        return View("Register");
    }

    [HttpPost("/registering")]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            if(db.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "is taken");
                return NewUser();
            }
                newUser.UserLevel = "Admin";

                PasswordHasher<User> hashBrowns = new PasswordHasher<User>();
                newUser.Password = hashBrowns.HashPassword(newUser, newUser.Password);

                db.Users.Add(newUser);
                db.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                HttpContext.Session.SetString("UserLevel", newUser.UserLevel);
                return RedirectToAction("Dashboard");
        }
        return NewUser();
    }

    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        List<User> AllUsers = db.Users.ToList();
        return View("Dashboard", AllUsers);
    }

    [HttpGet("/users/edit/{userId}")]
    public IActionResult EditOne(int userId)
    {
        return View("Edit");
    }
}