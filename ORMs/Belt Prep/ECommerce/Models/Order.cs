#pragma warning disable CS8618
namespace ECommerce.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Order
{
    [Key]
    public int OrderId {get; set;}

    [Required]
    [Display(Name = "Customer")]
    public int CustomerId {get; set;}

    [Required]
    public int ProductId {get; set;}

    [Required]
    public int OrderQuantity {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public Customer? Customer {get; set;}
    public Product? Product {get; set;}
}