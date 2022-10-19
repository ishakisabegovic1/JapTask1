namespace JAP.Core
{
  public class Admin : BaseEntity
  {
    public virtual ICollection<Comment>? Comments { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
  }
}
