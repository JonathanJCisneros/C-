using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntityFramework.Models;
namespace EntityFramework.Controllers;
    
public class PostController : Controller
{
    private EFLectureContext _context;

    // here we can "inject" our context service into the constructor
    public PostController(EFLectureContext context)
    {
        _context = context;
    }
    [HttpGet("/")]
    [HttpGet("/posts/all")]
    public IActionResult All()
    {
        List<Post> AllPosts = _context.Posts.ToList();

        return View("All", AllPosts);
    }

    [HttpGet("/post/new")]
    public IActionResult New()
    {
        return View("New");
    }

    [HttpPost("/post/create")]
    public IActionResult Create(Post newPost)
    {
        if(ModelState.IsValid == false)
        {
            return New();
        }
        _context.Posts.Add(newPost);
        _context.SaveChanges();
        return RedirectToAction("All");
    }
}
