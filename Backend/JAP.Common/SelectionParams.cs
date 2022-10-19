namespace JAP.Common
{
  public class SelectionParams : UserParams
  {
    public string nameFilter { get; set; } = "";
    public DateTime dateFilter { get; set; } = new DateTime(1900, 1, 1);

    public DateTime endDateFilter { get; set; } = new DateTime(2050, 1, 1);
    public string statusFilter { get; set; } = "";
    public string japFilter { get; set; } = "";

    public string OrderBy { get; set; } = "";

  }
}
