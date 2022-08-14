using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
namespace TheWall.Controllers;
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
    private TheWallContext db;

    public UserController(TheWallContext context)
    {
        db = context;
    }

    [HttpGet("/")]
    public IActionResult RegisterOrLogin()
    {
        if(loggedIn)
        {
            return RedirectToAction("TheWall", "Message");
        }
        return View("RegisterOrLogin");
    }

    [HttpPost("/register")]
    public IActionResult Register(User newUser)
    {
        if(ModelState.IsValid)
        {
            if(db.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("Email", "is taken");
                return RegisterOrLogin();
            }
        }

        if(ModelState.IsValid == false)
        {
            return RegisterOrLogin();
        }

        PasswordHasher<User> hashBrowns = new PasswordHasher<User>();
        newUser.Password = hashBrowns.HashPassword(newUser, newUser.Password);

        db.Users.Add(newUser);
        db.SaveChanges();
        HttpContext.Session.SetInt32("UserId", newUser.UserId);
        HttpContext.Session.SetString("name", newUser.FirstName);
        return RedirectToAction("TheWall", "Message");
    }

    [HttpPost("/login")]
    public IActionResult Login(UserLogin user)
    {
        if(ModelState.IsValid == false)
        {
            return RegisterOrLogin();
        }

        User? dbUser = db.Users.FirstOrDefault(u => u.Email == user.LoginEmail);

        if(dbUser == null)
        {
            ModelState.AddModelError("LoginEmail", "not found");
            return RegisterOrLogin();
        } 

        PasswordHasher<UserLogin> hashBrowns = new PasswordHasher<UserLogin>();
        PasswordVerificationResult pwCheck = hashBrowns.VerifyHashedPassword(user, dbUser.Password, user.LoginPassword);

        if(pwCheck == 0)
        {
            ModelState.AddModelError("LoginPassword", "is invalid");
            return RegisterOrLogin();
        }

        HttpContext.Session.SetInt32("UserId", dbUser.UserId);
        HttpContext.Session.SetString("name", dbUser.FirstName);
        return RedirectToAction("TheWall", "Message");
    }

    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("RegisterOrLogin");
    }
}