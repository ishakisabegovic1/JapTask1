using JAP.Core.Entities;

namespace JAP.Core
{
  public class Program : BaseEntity
  {
    public string Name { get; set; }

    public string? Curriculum { get; set; }

    public virtual ICollection<Selection> Selections { get; set; }

    public ICollection<ProgramItem> ProgramItems { get; set; }
  }
}
