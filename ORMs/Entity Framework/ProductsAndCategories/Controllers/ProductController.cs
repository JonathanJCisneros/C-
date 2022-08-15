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
            .ThenInclude(c => c.Category)
            .FirstOrDefault(p => p.ProductId == productId);
        ViewBag.Product = OneProduct;

        ViewBag.NotYetAssoc = db.Categories
            .Include(p => p.CategoriesWithProducts)
            .ThenInclude(p => p.Product)
            .Where(c => !c.CategoriesWithProducts.Any(c => c.ProductId == productId));
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