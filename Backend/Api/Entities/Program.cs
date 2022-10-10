namespace Api.Entities
{
  public class Program : BaseEntity
  {
    //public int Id { get; set; }
    public string Name { get; set; }

    public string? Curriculum { get; set; }

    public virtual ICollection<Selection> Selections { get; set; }


  }
}
