using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
namespace CRUDelicious.Controllers;
using System.Linq;
using System.Diagnostics;

public class DishController : Controller
{
    private CRUDeliciousContext _context;
    
    public DishController(CRUDeliciousContext context)
    {
        _context = context;
    }

    [HttpGet("/")]
    public IActionResult All()
    {
        List<Dish> dishList = _context.Dishes.OrderBy(dish => dish.CreatedAt).ToList();
        return View("All", dishList);
    }

    [HttpGet("/new")]
    public IActionResult New()
    {
        return View("NewDish");
    }

    [HttpPost("/dish/new")]
    public IActionResult Create(Dish newDish)
    {
        if(ModelState.IsValid == false)
        {
            return New();
        }
        _context.Dishes.Add(newDish);
        _context.SaveChanges();
        return RedirectToAction("All");
    }

    [HttpGet("/{dishId}")]
    public IActionResult GetOne(int dishId)
    {
        Dish theDish = _context.Dishes.First(dish => dish.DishId == dishId);
        return View("OneDish", theDish);
    }

    [HttpGet("/update/{dishId}")]
    public IActionResult Edit(int dishId)
    {
        Dish editDish = _context.Dishes.First(dish => dish.DishId == dishId);
        return View("NewDish", editDish);
    }

    [HttpPost("/updated/{dishId}")]
    public IActionResult Update(int dishId, Dish UpdatedDish)
    {
        Dish retrievedDish = _context.Dishes.First(dish => dish.DishId == dishId);
        retrievedDish.Name = UpdatedDish.Name;
        retrievedDish.Chef = UpdatedDish.Chef;
        retrievedDish.Calories = UpdatedDish.Calories;
        retrievedDish.Tastiness = UpdatedDish.Tastiness;
        retrievedDish.Description = UpdatedDish.Description;
        retrievedDish.UpdatedAt = DateTime.Now;
        _context.SaveChanges();
        return RedirectToAction("GetOne", dishId);
    }
}