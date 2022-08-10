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
        return View("NewOrUpdate");
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

    [HttpGet("/dish/{dishId}")]
    public IActionResult GetOne(int dishId)
    {
        Dish? theDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
        if(theDish == null)
        {
            return RedirectToAction("All");
        }
        return View("OneDish", theDish);
    }

    [HttpGet("/update/{dishId}")]
    public IActionResult Edit(int dishId)
    {
        Dish editDish = _context.Dishes.First(dish => dish.DishId == dishId);
        if(editDish == null)
        {
            return RedirectToAction("All");
        }
        return View("NewOrUpdate", editDish);
    }

    [HttpPost("/edited/{dishId}")]
    public IActionResult Update(int dishId, Dish UpdatedDish)
    {
        if(ModelState.IsValid)
        {
            Dish? retrievedDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
            if(retrievedDish == null)
            {
                return RedirectToAction("All");
            }
            retrievedDish.Name = UpdatedDish.Name;
            retrievedDish.Chef = UpdatedDish.Chef;
            retrievedDish.Calories = UpdatedDish.Calories;
            retrievedDish.Tastiness = UpdatedDish.Tastiness;
            retrievedDish.Description = UpdatedDish.Description;
            retrievedDish.UpdatedAt = DateTime.Now;
            _context.Dishes.Update(retrievedDish);
            _context.SaveChanges();
            return RedirectToAction("GetOne", new {dishId = dishId});
        }
        else
        {
            return Edit(dishId);
        }
    }
    [HttpGet("/delete/{dishId}")]
    public IActionResult Delete(int dishId)
    {
        Dish? deleteDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
        if(deleteDish == null)
        {
            return RedirectToAction("All");
        }
        else
        {
            _context.Dishes.Remove(deleteDish);
            _context.SaveChanges();
            return RedirectToAction("All");
        }
    }
}