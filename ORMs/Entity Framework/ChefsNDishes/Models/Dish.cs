#pragma warning disable CS8618
namespace ChefsNDishes.Models;
using System.ComponentModel.DataAnnotations;

public class Dish
{
    [Key]
    public int DishId {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters long")]
    [Display(Name = "Name of Dish")]
    public string Name {get; set;}

    [Required(ErrorMessage = "is required")]
    [Range(1, 100000, ErrorMessage = "must be greater than 0")]
    [Display(Name = "# of Calories")]
    public int Calories {get; set;}

    [Required(ErrorMessage = "is required")]
    [Range(1, 5, ErrorMessage = "must be between 1 and 5")]
    [Display(Name = "Tastiness")]
    public int Tastiness {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(5, ErrorMessage = "must be at least 5 characters long")]
    [Display(Name = "Description")]
    public string Description {get; set;}

    [Required]
    public int UserId {get; set;}

    
}