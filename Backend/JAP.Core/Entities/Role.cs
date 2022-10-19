using Microsoft.AspNetCore.Identity;

namespace JAP.Core
{
  public class Role : IdentityRole<int>
  {
    public ICollection<UserRole> UserRoles { get; set; }
  }
}
