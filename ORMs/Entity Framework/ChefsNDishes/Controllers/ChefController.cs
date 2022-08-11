using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
namespace ChefsNDishes.Controllers;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class ChefController : Controller
{
    private ChefsNDishesContext db;

    public ChefController(ChefsNDishesContext context)
    {
        db = context;
    }

    [HttpGet("/")]
    public IActionResult Chefs()
    {
        List<Chef> ChefList = db.Chefs
            .Include(dish => dish.CreatedDishes)
            .ToList();

        return View("AllChefs", ChefList);
    }

    [HttpGet("/new")]
    public IActionResult NewChef()
    {
        return View("NewChef");
    }

    [HttpPost("/new/chef")]
    public IActionResult CreateChef(Chef newChef)
    {
        if(ModelState.IsValid == false)
        {
            return NewChef();
        }
        db.Chefs.Add(newChef);
        db.SaveChanges();
        return RedirectToAction("Chefs");
    }

    [HttpGet("/dishes")]
    public IActionResult Dishes()
    {
        List<Dish> DishList = db.Dishes
            .Include(chef => chef.Chef)
            .ToList();
        return View("AllDishes", DishList);
    }

    [HttpGet("/dishes/new")]
    public IActionResult NewDish()
    {
        List<Chef> chefList = db.Chefs.ToList();
        ViewBag.cheflist = chefList;
        return View("NewDish");
    }

    [HttpPost("/new/dish")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(ModelState.IsValid == false)
        {
            return NewDish();
        }
        db.Dishes.Add(newDish);
        db.SaveChanges();
        return RedirectToAction("Dishes");
    }
}