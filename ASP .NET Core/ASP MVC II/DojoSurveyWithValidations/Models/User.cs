#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveyWithValidations.Models;

public class User
{
    [Required]
    [MinLength(2)]
    public string Name {get; set;}
    public string Location {get; set;}
    
    [Display(Name = "Favorite Language")]
    public string FaveLang {get; set;}
    
    [MinLength(20)]
    public string? Comment {get; set;}
}

