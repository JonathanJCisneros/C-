#pragma warning disable CS8618
namespace UserDashboard.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Comment
{
    [Key]
    public int CommentId {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(2, ErrorMessage = "must be at least 2 characters long")]
    [Display(Name = "Post a comment")]
    public string CommentString {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public int UserId {get; set;}
    public int MessageId {get; set;} 

    public User? User {get; set;}

    public Message? Message {get; set;}
}