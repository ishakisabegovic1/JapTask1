using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAP.Core;

namespace JAP.Database.Configurations
{
  public class SelectionConfiguration : IEntityTypeConfiguration<Selection>
  {
    public void Configure(EntityTypeBuilder<Selection> builder)
    {
      builder
          .HasOne(x => x.Program)
          .WithMany(x => x.Selections)
          .HasForeignKey(x => x.ProgramId);


    }
  }
}
