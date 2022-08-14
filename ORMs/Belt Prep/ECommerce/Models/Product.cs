#pragma warning disable CS8618
namespace ECommerce.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public int ProductId {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Name")]
    public string Name {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Image (url)")]
    public string Image {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Description")]
    public string Description {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Initial Quantity")]
    public int Quantity {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public List<Order> CustomerList {get; set;} = new List<Order>();
}