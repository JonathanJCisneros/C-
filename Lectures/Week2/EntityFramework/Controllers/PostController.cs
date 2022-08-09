using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntityFramework.Models;
namespace EntityFramework.Controllers;
using System.Linq;
    
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

    [HttpGet("/post/{postId}")]
    public IActionResult GetOne(int postId)
    {
        Post? thisPost = _context.Posts.FirstOrDefault(post => post.PostId == postId);
        if(thisPost == null)
        {
            return RedirectToAction("All");
        }
        return View("ViewOne", thisPost);
    }

    [HttpPost("/posts/{deletedPostId}/delete")]
    public IActionResult Delete(int deletedPostId)
    {
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
