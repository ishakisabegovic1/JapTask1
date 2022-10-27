using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Core.DTOs
{
  public class ProgramItemStudentView
  {
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int ProgramItemId { get; set; }
    public string StudentName { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public int OrderNumber { get; set; }
    public int ExpHours { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? DoneByCandidate { get; set; }

  }
}
