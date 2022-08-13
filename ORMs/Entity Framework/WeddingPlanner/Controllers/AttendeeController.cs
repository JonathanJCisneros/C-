using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
namespace WeddingPlanner.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class AttendeeController : Controller
{
    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("AttendeeId");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }
    private WeddingPlannerContext db;

    public AttendeeController(WeddingPlannerContext context)
    {
        db = context;
    }

    [HttpGet("/")]
    public IActionResult RegisterOrLogin()
    {
        if(loggedIn)
        {
            return RedirectToAction("Dashboard", "Wedding");
        }
        return View("RegisterOrLogin");
    }

    [HttpPost("/register")]
    public IActionResult Register(Attendee newAttendee)
    {
        if(ModelState.IsValid)
        {
            if(db.Attendees.Any(a => a.Email == newAttendee.Email))
            {
                ModelState.AddModelError("Email", "is taken");
                return RegisterOrLogin();
            }
        }

        if(ModelState.IsValid == false)
        {
            return RegisterOrLogin();
        }

        PasswordHasher<Attendee> hashBrowns = new PasswordHasher<Attendee>();
        newAttendee.Password = hashBrowns.HashPassword(newAttendee, newAttendee.Password);

        db.Attendees.Add(newAttendee);
        db.SaveChanges();
        HttpContext.Session.SetInt32("AttendeeId", newAttendee.AttendeeId);
        HttpContext.Session.SetString("name", newAttendee.FullName());
        return RedirectToAction("Dashboard", "Wedding");
    }

    [HttpPost("/login")]
    public IActionResult Login(AttendeeLogin attendee)
    {
        if(ModelState.IsValid == false)
        {
            return RegisterOrLogin();
        }

        Attendee? dbAttendee = db.Attendees.FirstOrDefault(a => a.Email == attendee.LoginEmail);

        if(dbAttendee == null)
        {
            ModelState.AddModelError("LoginEmail", "not found");
            return RegisterOrLogin();
        } 

        PasswordHasher<AttendeeLogin> hashBrowns = new PasswordHasher<AttendeeLogin>();
        PasswordVerificationResult pwCheck = hashBrowns.VerifyHashedPassword(attendee, dbAttendee.Password, attendee.LoginPassword);

        if(pwCheck == 0)
        {
            ModelState.AddModelError("LoginPassword", "is invalid");
            return RegisterOrLogin();
        }

        HttpContext.Session.SetInt32("AttendeeId", dbAttendee.AttendeeId);
        HttpContext.Session.SetString("name", dbAttendee.FullName());
        return RedirectToAction("Dashboard", "Wedding");
    }

    [HttpGet("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("RegisterOrLogin");
    }
}