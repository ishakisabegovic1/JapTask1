using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Common
{
  public class ItemParams : UserParams
  {
    public string nameFilter { get; set; } = "";
    public string descFilter { get; set; } = "";
    public string urlFilter { get; set; } = "";
    public int expHoursFilter { get; set; } = 0;

    public string OrderBy { get; set; } = "";
  }
}
