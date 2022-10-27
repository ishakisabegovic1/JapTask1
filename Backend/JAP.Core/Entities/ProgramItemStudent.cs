using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Core.Entities
{
  public class ProgramItemStudent : BaseEntity
  {

    public ProgramItem ProgramItem { get; set; }
    public int ProgramItemId { get; set; }

    public Student Student { get; set; }
    public int StudentId { get; set; }


    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? DoneByCandidate { get; set; }
    public string? StatusByCandidate { get; set; }

  }
}
