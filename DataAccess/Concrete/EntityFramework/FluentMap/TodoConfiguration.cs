using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.FluentMap
{
  public class TodoConfiguration : IEntityTypeConfiguration<Todo>
  {
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
      builder.ToTable("todos");

      // Key
      builder.HasKey(x => x.Id);

      // Property
      builder.Property(x => x.CreatedDate).HasColumnType("Datetime");
      builder.Property(x => x.CreatedDate).HasDefaultValueSql("GetDate()");
      builder.Property(x => x.DueDate).HasColumnType("Datetime");

      builder.Property(x => x.Task).IsRequired();
      builder.Property(x => x.Task).HasMaxLength(50);
      builder.Property(x => x.Description).HasMaxLength(1000);
      builder.Property(x => x.CreatedDate).IsRequired();
      builder.Property(x => x.DueDate).IsRequired(false);

      // Column Name
      builder.Property(x => x.Id).HasColumnName("todo_id");
      builder.Property(x => x.Task).HasColumnName("todo_task");
      builder.Property(x => x.Description).HasColumnName("todo_description");
      builder.Property(x => x.DueDate).HasColumnName("todo_due_date");
      builder.Property(x => x.CreatedDate).HasColumnName("todo_created_date");
    }
  }
}
