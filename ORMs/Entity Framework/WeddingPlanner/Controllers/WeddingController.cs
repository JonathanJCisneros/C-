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
        List<Wedding> AllWeddings = db.Weddings
            .Include(a => a.AttendanceList)
            .ToList();
        return View("Dashboard", AllWeddings);
    }

    [HttpGet("/{weddingId}")]
    public IActionResult WeddingDetails(int weddingId)
    {
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
        GuestList? currentGuest = db.GuestList.FirstOrDefault(g => g.)
    }
}