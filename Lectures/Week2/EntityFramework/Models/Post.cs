#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EntityFrameworkDemo.Models;

public class Post
{
    [Key]
    public int PostId {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters long")]
    [MaxLength(45, ErrorMessage = "must be shorter than 45 characters")]
    public string Topic {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters long")]

    public string Body {get; set;}

    [Display( Name = "Image URL")]
    public string? ImgUrl {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public int UserId {get; set;}
    public User? Author {get; set;} 
}