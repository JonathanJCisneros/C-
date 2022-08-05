using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618
namespace SessionAndValidation.Models;

public class User
{
    [Required(ErrorMessage = "is required")]
    [MinLength(3, ErrorMessage = "Must be at least 3 characters long")]
    [MaxLength(20)]
    [Display(Name = "Username")]
    public string Username {get; set;}

    [Required]
    [MinLength(8)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password {get; set;}


    [Compare("Password", ErrorMessage = "Must match Password!")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string? ConfirmPassword {get; set;}
}
