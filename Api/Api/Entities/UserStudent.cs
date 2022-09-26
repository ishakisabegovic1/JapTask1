using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
    public class UserStudent
    {
        
        public int Id { get; set; }

      
        public int UserId { get; set; }
        public virtual User User { get; set; }

      
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public string Comment { get; set; }
    }
}
