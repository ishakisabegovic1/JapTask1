using System.ComponentModel.DataAnnotations;

namespace Api.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Address { get; set; }
        [Required]
        
        public string StudentStatus { get; set; }
        
        public int SelectionId { get; set; }
        public virtual Selection? Selection { get; set; }
        
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
