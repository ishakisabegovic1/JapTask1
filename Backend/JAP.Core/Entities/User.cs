using Microsoft.AspNetCore.Identity;


namespace JAP.Core
{
  public class User : IdentityUser<int>
  {
    public ICollection<UserRole> UserRoles { get; set; }

    public Student? Student { get; set; }
    public Admin? Admin { get; set; }
  }
}
