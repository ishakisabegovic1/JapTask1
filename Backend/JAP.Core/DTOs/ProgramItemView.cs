using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Core.DTOs
{
  public class ProgramItemView
  {
    public int Id { get; set; }
    public int ProgramId { get; set; }
    public int ItemId { get; set; }
    public string ProgramName { get; set; }
    public string ItemName { get; set; }
    public int OrderNumber { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
    public int ExpHours { get; set; }

  }
}
