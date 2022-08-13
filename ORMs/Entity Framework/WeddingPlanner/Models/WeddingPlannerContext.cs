#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace WeddingPlanner.Models;

public class WeddingPlannerContext : DbContext 
{ 
    public WeddingPlannerContext(DbContextOptions options) : base(options) { }

    public DbSet<Attendee> Attendees { get; set; } 
}