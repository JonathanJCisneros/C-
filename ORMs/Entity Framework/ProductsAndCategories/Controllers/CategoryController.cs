using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
namespace ProductsAndCategories.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class CategoryController : Controller
{
    private ProductsAndCategoriesContext db;

    public CategoryController(ProductsAndCategoriesContext context)
    {
        db = context;
    }

    [HttpGet("/categories")]
    public IActionResult Categories()
    {
        List<Category> AllCategories = db.Categories.ToList();
        ViewBag.Categories = AllCategories;
        return View("AllCategories");
    }

    [HttpPost("/category/new")]
    public IActionResult NewCategory(Category newCategory)
    {
        if(ModelState.IsValid == false)
        {
            return Categories();
        }
        db.Categories.Add(newCategory);
        db.SaveChanges();
        return RedirectToAction("Categories");
    }

    [HttpGet("/categories/{categoryId}")]
    public IActionResult ProdForCat(int categoryId)
    {
        Category? OneCategory = db.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        ViewBag.Categories = OneCategory;

        List<Product> AllProducts = db.Products.ToList(); 
        return View("CategoriesForProducts", AllProducts);
    }

    [HttpPost("/category/addproduct/{categoryId}")]
    public IActionResult AddCategory(int categoryId, Association newProduct)
    {
        if(ModelState.IsValid == false)
        {
            return RedirectToAction("ProdForCat", new {categoryId = categoryId});
        }
        newProduct.CategoryId = categoryId;
        db.Associations.Add(newProduct);
        db.SaveChanges();
        return RedirectToAction("ProdForCat", new {categoryId = categoryId});
    }
}