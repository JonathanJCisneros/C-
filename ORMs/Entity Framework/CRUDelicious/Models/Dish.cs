#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Name of Dish")]
    public string Name { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Chef's Name")]
    public string Chef { get; set; }

    [Required(ErrorMessage = "is required")]
    [Range(1, 5)]
    [Display(Name = "Tastiness")]
    public int Tastiness { get; set; }

    [Required(ErrorMessage = "is required")]
    [Range(1, 100000, ErrorMessage = "must be greater than 0.")]
    [Display(Name = "# of Calories")]
    public int Calories { get; set; }

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Description")]
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}


