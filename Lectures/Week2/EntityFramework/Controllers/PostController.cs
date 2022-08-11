using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkDemo.Models;
namespace EntityFrameworkDemo.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class PostController : Controller
{
    private EFLectureContext _context;

    // here we can "inject" our context service into the constructor
    public PostController(EFLectureContext context)
    {
        _context = context;
    }

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

    [HttpGet("/posts/all")]
    public IActionResult All()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }
        List<Post> AllPosts = _context.Posts
        .Include(post => post.Author)
        .ToList();

        return View("All", AllPosts);
    }

    [HttpGet("/post/new")]
    public IActionResult New()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }
        return View("New");
    }

    [HttpPost("/post/create")]
    public IActionResult Create(Post newPost)
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }
        if(ModelState.IsValid == false)
        {
            return New();
        }
        if(uid != null)
        {
            newPost.UserId = (int)uid;
        }
        _context.Posts.Add(newPost);
        _context.SaveChanges();
        return RedirectToAction("All");
    }

    [HttpGet("/post/{postId}")]
    public IActionResult GetOne(int postId)
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }
        Post? thisPost = _context.Posts
        .Include(u => u.Author)
        .FirstOrDefault(post => post.PostId == postId);
        if(thisPost == null || thisPost.UserId != uid)
        {
            return RedirectToAction("All");
        }
        return View("ViewOne", thisPost);
    }

    [HttpPost("/posts/{deletedPostId}/delete")]
    public IActionResult Delete(int deletedPostId)
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }
        Post? post = _context.Posts.FirstOrDefault(post => post.PostId == deletedPostId);
        if(post != null)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
        return RedirectToAction("All");
    }

    [HttpGet("/posts/{postToBeEdited}")]
    public IActionResult EditPost(int postToBeEdited)
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }
        Post? editedPost = _context.Posts.FirstOrDefault(post => post.PostId == postToBeEdited);
        if(editedPost == null)
        {
            return RedirectToAction("All");
        }
        return View("Edit", editedPost);
    }

    [HttpPost("/post/update")]
    public IActionResult Update(Post editedPost)
    {
        if(!loggedIn)
        {
            return RedirectToAction("Index", "User");
        }
        if(ModelState.IsValid)
        {
            Post? dbPost = _context.Posts.FirstOrDefault(post => post.PostId == editedPost.PostId);
            if(dbPost == null)
            {
                return RedirectToAction("All");
            }
            dbPost.Topic = editedPost.Topic;
            dbPost.Body = editedPost.Body;
            dbPost.ImgUrl = editedPost.ImgUrl;
            dbPost.UpdatedAt = DateTime.Now;
            _context.Posts.Update(dbPost);
            _context.SaveChanges();
            return RedirectToAction("GetOne", dbPost.PostId);
        }
        else
        {
            return EditPost(editedPost.PostId);
        }
        
    }
}
