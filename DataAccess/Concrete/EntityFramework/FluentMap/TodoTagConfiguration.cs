using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.FluentMap
{
  public class TodoTagConfiguration : IEntityTypeConfiguration<TodoTag>
  {
    public void Configure(EntityTypeBuilder<TodoTag> builder)
    {
      builder.ToTable("todo_tags");

      // Key
      builder.HasKey(x => x.Id);

      // Relationship
      builder.HasOne(x => x.Todo)
        .WithMany(x => x.TodoTags)
        .HasForeignKey(x => x.TodoId);

      builder.HasOne(x => x.Tag)
        .WithMany(x => x.TodoTags)
        .HasForeignKey(x => x.TagId);

      builder.Property(x => x.Id).HasColumnName("todo_tag_id");
      builder.Property(x => x.TagId).HasColumnName("todo_tag_tag_id");
      builder.Property(x => x.TodoId).HasColumnName("todo_tag_todo_id");
    }
  }
}
