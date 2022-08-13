#pragma warning disable CS8618
namespace WeddingPlanner.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Wedding
{

    [Key]
    public int WeddingId {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters long")]
    [Display(Name = "Wedder One")]
    public string WedderOne {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters long")]
    [Display(Name = "Wedder Two")]
    public string WedderTwo {get; set;}

    [Required(ErrorMessage = "is required")]
    [MyDate(ErrorMessage = "must be a future date")]
    [Display(Name = "Date")]
    public DateTime Date {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Wedding Address")]
    public string Address {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    [Required]
    public int PlannerId {get; set;} 

    public List<GuestList> AttendanceList {get; set;} = new List<GuestList>();
}

[NotMapped]
public class MyDateAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        DateTime d = Convert.ToDateTime(value);
        return d >= DateTime.Now;
    }
}