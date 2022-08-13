using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
namespace ProductsAndCategories.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class ProductController : Controller
{

    private ProductsAndCategoriesContext db;

    public ProductController(ProductsAndCategoriesContext context)
    {
        db = context;
    }

    [HttpGet("/products")]
    public IActionResult Products()
    {
        List<Product> AllProducts = db.Products.ToList();
        ViewBag.Products = AllProducts;
        return View("AllProducts");
    }

    [HttpPost("/product/new")]
    public IActionResult NewProduct(Product newProduct)
    {
        if(ModelState.IsValid == false)
        {
            return Products();
        }
        db.Products.Add(newProduct);
        db.SaveChanges();
        return RedirectToAction("Products");
    }

    [HttpGet("/products/{productId}")]
    public IActionResult CatForProd(int productId)
    {
        Product? OneProduct = db.Products
            .Include(p => p.ProductsWithCategories)
            .FirstOrDefault(p => p.ProductId == productId);
        ViewBag.Product = OneProduct;

        List<Category> AllCategories = db.Categories.ToList();

        List<Category> SomeCategories = new List<Category>();

        foreach(Association c in OneProduct.ProductsWithCategories)
        {
            SomeCategories.Add(c.Category);
        }
        List<Category> NotYetAssoc = AllCategories.Except(SomeCategories).ToList();
        ViewBag.NotYetAssoc = NotYetAssoc;
        return View("CategoriesForProducts");
    }

    [HttpPost("/product/addcategory/{productId}")]
    public IActionResult AddCategory(int productId, Association newCategory)
    {
        if(ModelState.IsValid == false)
        {
            return CatForProd(productId);
        }
        newCategory.ProductId = productId;
        db.Associations.Add(newCategory);
        db.SaveChanges();
        return RedirectToAction("CatForProd", new {productId = productId});
    }
}