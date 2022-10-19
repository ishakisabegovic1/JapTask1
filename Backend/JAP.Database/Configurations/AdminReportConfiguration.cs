using JAP.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Database.Configurations
{
  public class AdminReportConfiguration : IEntityTypeConfiguration<AdminReportDto>
  {
    public void Configure(EntityTypeBuilder<AdminReportDto> builder)
    {
      builder
        .ToTable("AdminReports", x => x.ExcludeFromMigrations())
        .HasNoKey();
    }
  }
}
