using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojodachiGame.Models;
namespace DojodachiGame.Controllers;

public class DojodachiController : Controller
{
    [HttpGet("")]
    public IActionResult Dachi()
    {   
        Dojodachi dachi1 = new Dojodachi();
        return View("Dojodachi", dachi1);
    }
}