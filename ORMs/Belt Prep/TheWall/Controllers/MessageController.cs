using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
namespace TheWall.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class MessageController : Controller
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

    public MessageController(TheWallContext context)
    {
        db = context;
    }

    [HttpGet("/thewall")]
    public IActionResult TheWall()
    {
        if(!loggedIn)
        {
            return RedirectToAction("RegisterOrLogin", "User");
        }
        List<Message> AllMessages = db.Messages
            .Include(c => c.User)
            .Include(c => c.CommentList)
            .ThenInclude(c => c.User)
            .OrderByDescending(m => m.CreatedAt)
            .ToList();
        ViewBag.All = AllMessages;
        return View("TheWall");
    }

    [HttpPost("/post/new")]
    public IActionResult CreateMessage(Message newMessage)
    {
        if(!loggedIn)
        {
            return RedirectToAction("RegisterOrLogin", "User");
        }
        if(ModelState.IsValid == false)
        {
            return TheWall();
        }
        newMessage.UserId = (int)uid;
        db.Messages.Add(newMessage);
        db.SaveChanges();
        return RedirectToAction("TheWall");
    }

    [HttpGet("/delete/{messageId}")]
    public IActionResult Delete(int messageId)
    {
        if(!loggedIn)
        {
            return RedirectToAction("RegisterOrLogin", "User");
        }
        Message? message = db.Messages.FirstOrDefault(m => m.MessageId == messageId);
        if(message == null)
        {
            return RedirectToAction("TheWall");
        }

        db.Messages.Remove(message);
        db.SaveChanges();
        return RedirectToAction("TheWall");
    }

    [HttpPost("/comment/{messageId}/new")]
    public IActionResult CreateComment(int messageId, Comment newComment)
    {
        if(!loggedIn)
        {
            return RedirectToAction("RegisterOrLogin", "User");
        }
        if(ModelState.IsValid == false)
        {
            return TheWall();
        }
        newComment.MessageId = messageId;
        newComment.UserId = (int)uid;
        db.Comments.Add(newComment);
        db.SaveChanges();
        return RedirectToAction("TheWall");
    }
}