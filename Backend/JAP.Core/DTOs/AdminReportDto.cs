namespace JAP.Core
{
  public class AdminReportDto
  {

    public string SelName { get; set; }
    public string PrName { get; set; }
    public int numberOfStudents { get; set; }

    public int numberOfSuccess { get; set; }
    public decimal SuccessRate { get; set; }

    //public int overallSuccess { get; set; }

  }
}
