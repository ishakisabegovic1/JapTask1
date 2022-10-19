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
  public class CommentConfiguration : IEntityTypeConfiguration<Comment>
  {
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
      builder
           .HasKey(x => x.Id);


    }
  }
}
