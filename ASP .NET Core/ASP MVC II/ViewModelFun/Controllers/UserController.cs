using Microsoft.AspNetCore.Mvc;

namespace ViewModelFun.Models;

public class UserController : Controller
{
    [HttpGet("/")]
    public IActionResult Message()
    {
        string message = "testing tesing testing I cant spell sidfgbileurgbavilaierigbgvssjkabegvbelr";
        return View("Index", message);
    }

    [HttpGet("/numbers")]
    public IActionResult Numbers()
    {
        int[] numbers = {1,2,3,4,5};
        return View("Numbers", numbers);
    }

    [HttpGet("/user")]
    public IActionResult UserDetail()
    {
        User user1 = new User("Jackson", "Henry");

        return View("User", user1);
    }

    [HttpGet("/users")]
    public IActionResult UserList()
    {
        List<User> userList = new List<User>()
        {
            new User("Jonathan", "Cisneros"),
            new User("Jackson", "Henry"),
            new User("Kevin", "Oreo"),
            new User("Winter", "Perrone")
        };

        return View("Users", userList);
    }
}