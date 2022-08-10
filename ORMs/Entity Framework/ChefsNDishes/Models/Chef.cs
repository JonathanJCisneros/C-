#pragma warning disable CS8618
namespace ChefsNDishes.Models;
using System.ComponentModel.DataAnnotations;

public class Chef
{
    [Key]
    public int ChefId {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(3, ErrorMessage = "must be at least 3 characters long")]
    [Display(Name = "First Name")]
    public string FirstName {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(3, ErrorMessage = "must be at least 3 characters long")]
    [Display(Name = "Last Name")]
    public string LastName {get; set;}

    [Required(ErrorMessage = "is required")]
    [DataType(DataType.Date)]
    [Display(Name = "Date of Birth")]
    public DateOnly DOB {get; set;}

    
}