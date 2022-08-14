#pragma warning disable CS8618
namespace TheWall.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Message
{

    [Key]
    public int MessageId {get; set;}

    [Required(ErrorMessage = "is required")]
    [Display(Name = "Post a message")]
    [MinLength(2, ErrorMessage = "Message must be at least 2 characters long")]
    public string MessageString {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;

    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public int UserId {get; set;}

    public List<Comment> CommentList {get; set;} = new List<Comment>();

    public User? User {get; set;}
}