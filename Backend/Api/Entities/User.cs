using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Api.Entities
{
  public class User : IdentityUser<int>
  {
    //public string UserName { get; set; }

    //public string Password { get; set; }

    //public virtual ICollection<Comment>? Comments { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }

    public Student? Student { get; set; }
    public Admin? Admin { get; set; }
  }
}
