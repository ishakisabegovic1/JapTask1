using JAP.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAP.Core.Entities;

namespace JAP.Database.Configurations
{
  public class ProgramItemConfiguration : IEntityTypeConfiguration<ProgramItem>
  {
    public void Configure(EntityTypeBuilder<ProgramItem> builder)
    {
      builder
        .HasMany(x => x.Students)
        .WithOne(x => x.ProgramItem)
        .HasForeignKey(x => x.ProgramItemId);

    }
  }
}
