#pragma warning disable CS8618
namespace ECommerce.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Customer
{
    [Key]
    public int CustomerId {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "First Name")]
    public string FirstName {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Last Name")]
    public string LastName {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public List<Order> OrderList {get; set;} = new List<Order>();

    public string FullName()
    {
        return $"{FirstName} {LastName}";
    }
}