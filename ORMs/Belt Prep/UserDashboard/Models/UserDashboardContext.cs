#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace UserDashboard.Models;

public class UserDashboardContext : DbContext 
{ 
    public UserDashboardContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; } 
    public DbSet<Message> Messages { get; set; } 
    public DbSet<Comment> Comments { get; set; } 
}