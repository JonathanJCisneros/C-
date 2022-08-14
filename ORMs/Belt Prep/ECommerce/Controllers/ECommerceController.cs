using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
namespace ECommerce.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class ECommerceController : Controller
{
    private ECommerceContext db;

    public ECommerceController(ECommerceContext context)
    {
        db = context;
    }

    [HttpGet("")]
    public IActionResult Dashboard()
    {
        List<Product> AllProducts = db.Products.ToList();
        List<Order> AllOrders = db.Orders
            .Include(c => c.Customer)
            .ToList();
        ViewBag.Orders = AllOrders;
        List<Customer> AllCustomers = db.Customers.ToList();
        ViewBag.Customers = AllCustomers;
        return View("Dashboard", AllProducts);
    }

    [HttpGet("/orders")]
    public IActionResult Orders()
    {
        List<Customer> AllCustomers = db.Customers.ToList();
        ViewBag.Customers = AllCustomers;
        
        List<Product> AllProducts = db.Products.ToList();
        ViewBag.Products = AllProducts;
        
        List<Order> AllOrders = db.Orders
            .Include(o => o.Customer)
            .Include(o => o.Product)
            .ToList();
        ViewBag.Orders = AllOrders;

        return View("Orders");
    }

    [HttpPost("/order/new")]
    public IActionResult AddOrder(Order newOrder)
    {
        if(ModelState.IsValid == false)
        {
            return Orders();
        }
        Product? orderedProduct = db.Products.FirstOrDefault(p => p.ProductId == newOrder.ProductId);

        orderedProduct.Quantity = orderedProduct.Quantity - newOrder.OrderQuantity;
        db.Products.Update(orderedProduct);
        db.Orders.Add(newOrder);
        db.SaveChanges();
        return RedirectToAction("Orders");
    }

    [HttpGet("/customers")]
    public IActionResult Customers()
    {
        List<Customer> AllCustomers = db.Customers.ToList();
        ViewBag.Customers = AllCustomers;
        return View("Customers");
    }

    [HttpPost("/customer/new")]
    public IActionResult AddCustomer(Customer newCustomer)
    {
        if(ModelState.IsValid == false)
        {
            return Customers();
        }
        db.Customers.Add(newCustomer);
        db.SaveChanges();
        return RedirectToAction("Customers");
    }

    [HttpGet("/products")]
    public IActionResult Products()
    {   
        List<Product> AllProducts = db.Products.ToList();
        ViewBag.Products = AllProducts;
        return View("Products");
    }

    [HttpPost("/product/new")]
    public IActionResult AddProduct(Product newProduct)
    {
        if(ModelState.IsValid == false)
        {
            return Products();
        }
        db.Products.Add(newProduct);
        db.SaveChanges();
        return RedirectToAction("Products");
    }

    [HttpGet("/settings")]
    public IActionResult Settings()
    {
        return View("Settings");
    }
}