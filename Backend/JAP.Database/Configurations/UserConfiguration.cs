using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using JAP.Core;

namespace JAP.Database.Configurations
{
  public class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder
        .HasMany(ur => ur.UserRoles)
        .WithOne(u => u.User)
        .HasForeignKey(ur => ur.UserId)
        .IsRequired();

      builder
        .HasOne(x => x.Student)
        .WithOne(x => x.User);

      builder
        .HasOne(x => x.Admin)
        .WithOne(x => x.User);
    }
  }
}
