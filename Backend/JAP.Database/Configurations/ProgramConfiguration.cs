using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JAP.Core;
using System.Security.Cryptography.X509Certificates;

namespace JAP.Database.Configurations
{
  public class ProgramConfiguration : IEntityTypeConfiguration<Program>
  {
    public void Configure(EntityTypeBuilder<Program> builder)
    {

      builder
        .HasMany(x => x.Selections)
        .WithOne(x => x.Program);

      builder
        .HasMany(x => x.ProgramItems)
        .WithOne(p => p.Program)
        .HasForeignKey(x => x.ProgramId)
        .IsRequired();




    }
  }
}
