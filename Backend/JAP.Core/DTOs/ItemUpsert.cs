using JAP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Core.DTOs
{
  public class ItemUpsert
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? Url { get; set; }
    public int ExpectedNumberOfHours { get; set; }
    public bool IsLecture { get; set; }

  }
}
