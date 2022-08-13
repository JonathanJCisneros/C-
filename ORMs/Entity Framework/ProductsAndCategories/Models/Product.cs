#pragma warning disable CS8618
namespace ProductsAndCategories.Models;
using System.ComponentModel.DataAnnotations;

public class Product
{

    [Key]
    public int ProductId {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Name")]
    public string Name {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Description")]
    public string Description {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Price")]
    public int Price {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public List<Category> CategoryList {get; set;} = new List<Category>();
}