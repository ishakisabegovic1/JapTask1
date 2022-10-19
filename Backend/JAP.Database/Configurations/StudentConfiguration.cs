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
  public class StudentConfiguration : IEntityTypeConfiguration<Student>
  {
    public void Configure(EntityTypeBuilder<Student> builder)
    {
      builder
          .HasOne(x => x.Selection)
          .WithMany(x => x.Students)
          .HasForeignKey(x => x.SelectionId);

      builder
          .HasMany(x => x.Comments).WithOne(x => x.Student);


    }
  }
}
