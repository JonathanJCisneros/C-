#pragma warning disable CS8618
namespace EntityFrameworkDemo.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserPostLike
{
    [Key]
    public int UserPostLikeId {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public int UserId {get; set;}
    public User? User {get; set;}
    public int PostId {get; set;}
    public Post? Post {get; set;}
}