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
  public class RoleConfiguration : IEntityTypeConfiguration<Role>
  {
    public void Configure(EntityTypeBuilder<Role> builder)
    {
      builder
         .HasMany(ur => ur.UserRoles)
         .WithOne(u => u.Role)
         .HasForeignKey(ur => ur.RoleId)
         .IsRequired();


    }
  }
}
