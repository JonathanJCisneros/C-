#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace EntityFramework.Models;

public class EFLectureContext : DbContext 
{ 
    public EFLectureContext(DbContextOptions options) : base(options) { }
    // the "Monsters" table name will come from the DbSet property name
    public DbSet<Post> Posts { get; set; } 
}