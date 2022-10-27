using JAP.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace JAP.Core
{
  public class Student : BaseEntity
  {
    //public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Address { get; set; }
    [Required]

    public string Status { get; set; }

    public int SelectionId { get; set; }
    public virtual Selection? Selection { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }
    //public int ProgramId { get; set; }

    public ICollection<ProgramItemStudent> Items { get; set; }
  }
}
