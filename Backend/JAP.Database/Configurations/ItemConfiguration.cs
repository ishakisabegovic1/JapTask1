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
  public class ItemConfiguration : IEntityTypeConfiguration<Item>
  {
    public void Configure(EntityTypeBuilder<Item> builder)
    {

      builder
        .HasMany(x => x.ProgramItems)
        .WithOne(x => x.Item)
        .HasForeignKey(x => x.ItemId);




    }
  }
}
