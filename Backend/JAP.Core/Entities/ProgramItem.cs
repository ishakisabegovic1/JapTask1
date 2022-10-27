using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Core.Entities
{
  public class ProgramItem : BaseEntity
  {

    public Program Program { get; set; }
    public int ProgramId { get; set; }
    public Item Item { get; set; }
    public int ItemId { get; set; }
    public int OrderNumber { get; set; }
    public ICollection<ProgramItemStudent> Students { get; set; }
  }
}
