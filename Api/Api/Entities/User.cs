using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Api.Entities
{
    public class User 
    {
        public int Id { get; set; }

        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual ICollection<UserStudent>? Comments { get; set; }

    }
}
