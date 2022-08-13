using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
namespace WeddingPlanner.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class WeddingController : Controller
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

    public WeddingController(WeddingPlannerContext context)
    {
        db = context;
    }

    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        if(!loggedIn)
        {
            return RedirectToAction("RegisterOrLogin", "Attendee");
        }
        List<Wedding> AllWeddings = db.Weddings
            .Include(a => a.AttendanceList)
            .ToList();
        return View("Dashboard", AllWeddings);
    }

    [HttpGet("/{weddingId}")]
    public IActionResult WeddingDetails(int weddingId)
    {
        if(!loggedIn)
        {
            return RedirectToAction("RegisterOrLogin", "Attendee");
        }
        Wedding? wedding = db.Weddings
            .Include(g => g.AttendanceList)
            .ThenInclude(a => a.Attendee)
            .FirstOrDefault(w => w.WeddingId == weddingId);
        
        if(wedding == null)
        {
            return RedirectToAction("Dashboard");
        }
        return View("WeddingDetails", wedding);
    }

    [HttpGet("/delete/{weddingId}")]
    public IActionResult DeleteOne(int weddingId)
    {
        if(!loggedIn)
        {
            return RedirectToAction("RegisterOrLogin", "Attendee");
        }
        Wedding? wedding = db.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
        if(wedding == null)
        {
            return RedirectToAction("Dashboard");
        }

        db.Weddings.Remove(wedding);
        db.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpGet("/wedding/{weddingId}/attend")]
    public IActionResult Attend(int weddingId)
    {
        if(!loggedIn)
        {
            return RedirectToAction("RegisterOrLogin", "Attendee");
        }
        GuestList? currentGuest = db.GuestList.FirstOrDefault(g => g.WeddingId == weddingId && g.AttendeeId == uid);
        if(currentGuest == null)
        {
            GuestList newGuest = new GuestList()
            {
                WeddingId = weddingId,
                AttendeeId = (int)uid
            };
            db.GuestList.Add(newGuest);
        }
        else
        {
            db.Remove(currentGuest);
        }
        db.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpGet("/wedding/new")]
    public IActionResult Plan()
    {
        if(!loggedIn)
        {
            return RedirectToAction("RegisterOrLogin", "Attendee");
        }
        return View("NewWedding");
    }

    [HttpPost("/wedding/create")]
    public IActionResult Create(Wedding wedding)
    {
        if(!loggedIn)
        {
            return RedirectToAction("RegisterOrLogin", "Attendee");
        }
        if(ModelState.IsValid == false)
        {
            return Plan();
        }
        wedding.PlannerId = (int)uid;
        db.Weddings.Add(wedding);
        db.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpGet("/wedding/{weddingId}")]
    public IActionResult OneWedding(int weddingId)
    {
        if(!loggedIn)
        {
            return RedirectToAction("RegisterOrLogin", "Attendee");
        }
        Wedding? wedding = db.Weddings
            .Include(g => g.AttendanceList)
            .ThenInclude(g => g.Attendee)
            .FirstOrDefault(w => w.WeddingId == weddingId);
        if(wedding == null)
        {
            return RedirectToAction("Dashboard");
        }
        return View("OneWedding", wedding);
    }
}