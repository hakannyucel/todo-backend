using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.FluentMap
{
  public class LogConfiguration : IEntityTypeConfiguration<Log>
  {
    public void Configure(EntityTypeBuilder<Log> builder)
    {
      builder.ToTable("logs");
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Detail).IsRequired();
      builder.Property(x => x.Date).IsRequired();
      builder.Property(x => x.Audit).IsRequired();

      builder.Property(x => x.Audit).HasMaxLength(50);

      builder.Property(x => x.Id).HasColumnName("id");
      builder.Property(x => x.Detail).HasColumnName("detail");
      builder.Property(x => x.Date).HasColumnName("date");
      builder.Property(x => x.Audit).HasColumnName("audit");
    }
  }
}
