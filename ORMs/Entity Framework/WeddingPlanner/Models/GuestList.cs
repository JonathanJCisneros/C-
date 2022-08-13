#pragma warning disable CS8618
namespace WeddingPlanner.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class GuestList
{
    [Key]
    public int GuestListId {get; set;}

    [Required]
    public int AttendeeId {get; set;}

    [Required]
    public int WeddingId {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    public Wedding? Wedding {get; set;}
    public Attendee? Attendee {get; set;}
}