#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace EntityFrameworkDemo.Models;

public class EFLectureContext : DbContext 
{ 
    public EFLectureContext(DbContextOptions options) : base(options) { }

    public DbSet<Post> Posts { get; set; } 
    public DbSet<User> Users { get; set; }
    public DbSet<UserPostLike> UserPostLikes { get; set; }
}