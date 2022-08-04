#pragma warning disable CS8618

namespace ASPNetDemo.Models;

public class User
{
    public string FirstName {get; set;} 
    public string LastName {get; set;}
    public int Age {get; set;}

    public string FullName()
    {
        return $"{FirstName} {LastName}";
    }
}