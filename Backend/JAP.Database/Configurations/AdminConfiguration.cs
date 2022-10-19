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
  public class AdminConfiguration : IEntityTypeConfiguration<Admin>
  {
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
      builder
          .HasMany(x => x.Comments).WithOne(x => x.Admin);


    }
  }
}
