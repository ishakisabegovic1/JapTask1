namespace JAP.Core
{
  public class BaseEntity
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
  }
}
