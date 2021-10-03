using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.FluentMap
{
  public class TagConfiguration : IEntityTypeConfiguration<Tag>
  {
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
      builder.ToTable("tags");

      // Key
      builder.HasKey(x => x.Id);

      // Property
      builder.Property(x => x.Name).IsRequired();
      builder.Property(x => x.Name).HasMaxLength(30);

      // Column Name
      builder.Property(x => x.Id).HasColumnName("tag_id");
      builder.Property(x => x.Name).HasColumnName("tag_name");
    }
  }
}
