#pragma warning disable CS8618
namespace ProductsAndCategories.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Category
{

    [Key]
    public int CategoryId {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Name")]
    public string Name {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public List<Association> CategoriesWithProducts {get; set;} = new List<Association>();
}