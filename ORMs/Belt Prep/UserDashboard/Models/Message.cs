#pragma warning disable CS8618
namespace UserDashboard.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Message
{
    [Key]
    public int MessageId {get; set;}

    [Required(ErrorMessage = "is required")]
    [MinLength(3, ErrorMessage = "Message must be at least 3 characters long")]
    public string MessageString {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public int UserId {get; set;}

    public int AuthorId {get; set;}

    public List<Comment> CommentList {get; set;} = new List<Comment>();

    public User? User {get; set;}

}