using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Core.DTOs
{
  public class ProgramItemUpsert
  {
    public int Id { get; set; }
    public int ProgramId { get; set; }
    public int ItemId { get; set; }
    public int OrderNumber { get; set; }
  }
}
