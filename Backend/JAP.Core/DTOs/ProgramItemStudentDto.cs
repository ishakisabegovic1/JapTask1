using JAP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Core.DTOs
{
  public class ProgramItemStudentDto
  {
    public int Id { get; set; }
    public int ProgramItemId { get; set; }
    public int StudentId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? DoneByCandidate { get; set; }
    public string? StatusByCandidate { get; set; }
  }
}
