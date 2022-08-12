using Microsoft.AspNetCore.Mvc;
using BankAccounts.Models;
namespace BankAccounts.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public class UserController : Controller
{
    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("UserId");
        }
    }

    private bool loggedIn
    {
        get
        {
            return uid != null;
        }
    }
    private BankAccountsContext db;

    public UserController(BankAccountsContext context)
    {
        db = context;
    }

    [HttpGet("/")]
    public IActionResult Registration()
    {
        if(loggedIn)
        {
            return RedirectToAction("Account");
        }
        return View("Register");
    }

    [HttpPost("/register")]
    public IActionResult NewUser(User newUser)
    {
        if(loggedIn)
        {
            return RedirectToAction("Account");
        }
        if(ModelState.IsValid == false)
        {
            return Registration();
        }
        if(db.Users.Any(user => user.Email == newUser.Email))
        {
            ModelState.AddModelError("Email", "is taken");
        }

        PasswordHasher<User> hashBrowns = new PasswordHasher<User>();
        newUser.Password = hashBrowns.HashPassword(newUser, newUser.Password);
        db.Users.Add(newUser);
        db.SaveChanges();
        HttpContext.Session.SetInt32("UserId", newUser.UserId);
        HttpContext.Session.SetString("name", newUser.FullName());
        return Accounts();
    }

    [HttpGet("/login")]
    public IActionResult Login()
    {
        if(loggedIn)
        {
            return RedirectToAction("Account");
        }
        return View("Login");
    }

    [HttpPost("/user/login")]
    public IActionResult LoggedIn(LoginUser user)
    {
        if(loggedIn)
        {
            return RedirectToAction("Account");
        }
        if(ModelState.IsValid == false)
        {
            return Login();
        }
        
        User? dbUser = db.Users.FirstOrDefault(User => User.Email == user.LoginEmail);

        if(dbUser == null)
        {
            ModelState.AddModelError("LoginEmail", "not found");
            return Login();
        }

        PasswordHasher<LoginUser> hashBrowns = new PasswordHasher<LoginUser>();
        PasswordVerificationResult pwCheck = hashBrowns.VerifyHashedPassword(user, dbUser.Password, user.LoginPassword);

        if(pwCheck == 0)
        {
            ModelState.AddModelError("LoginPassword", "is not correct");
            return Login();
        }

        HttpContext.Session.SetInt32("UserId", dbUser.UserId);
        HttpContext.Session.SetString("name", dbUser.FullName());
        return Accounts();
    }

    [HttpGet("/account")]
    public IActionResult Accounts()
    {
        if(!loggedIn)
        {
            return RedirectToAction("Login");
        }
        List<Transaction> TransactionList = db.Transactions
            .Where(trans => trans.UserId == HttpContext.Session.GetInt32("UserId"))
            .OrderByDescending(trans => trans.CreatedAt)
            .ToList();

        int SumOfTransactions = TransactionList.Sum(trans => trans.Amount);
        
        ViewBag.Sum = SumOfTransactions;
        ViewBag.Transactions = TransactionList;
        return View("Account");
    }

    [HttpPost("/account/transaction")]
    public IActionResult Transaction(Transaction newTransaction)
    {
        if(!loggedIn)
        {
            return RedirectToAction("Login");
        }
        if(ModelState.IsValid == false)
        {
            return Accounts();
        }
        newTransaction.UserId = (int)uid;
        db.Transactions.Add(newTransaction);
        db.SaveChanges();
        return Accounts();
    }

    [HttpPost("/logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}