using System.ComponentModel.DataAnnotations.Schema;

namespace JAP.Core
{
  public class Selection : BaseEntity
  {
    //public int Id { get; set; }

    public string Name { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Status { get; set; }

    public int ProgramId { get; set; }
    public virtual Program Program { get; set; }

    public virtual ICollection<Student> Students { get; set; }



  }
}
