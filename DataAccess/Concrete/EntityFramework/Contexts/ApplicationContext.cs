using DataAccess.Concrete.EntityFramework.FluentMap;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
  public class ApplicationContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=DESKTOP-LP4PKBU\\SQLEXPRESS;Database=todoapp;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TodoTag> TodoTags { get; set; }
  }
}
