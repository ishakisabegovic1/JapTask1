using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entities
{
  public class Comment : BaseEntity
  {

    //public int Id { get; set; }


    public int AdminId { get; set; }
    public virtual Admin Admin { get; set; }


    public int StudentId { get; set; }
    public virtual Student Student { get; set; }

    public string comment { get; set; }
  }
}
