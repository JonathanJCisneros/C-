#pragma warning disable CS8618
namespace ProductsAndCategories.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Association
{

    [Key]
    public int AssociationId {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Add Product")]
    public int ProductId {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Add Category")]
    public int CategoryId {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public Product? Product {get; set;}
    public Category? Category {get; set;}
}