using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
  public class Selection : BaseEntity
  {
    //public int Id { get; set; }

    public string Name { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Status { get; set; }

    public int JapId { get; set; }
    public virtual Program Jap { get; set; }

    public virtual ICollection<Student> Students { get; set; }



  }
}
