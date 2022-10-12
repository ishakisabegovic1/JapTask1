namespace Api.DTOs
{
  public class AdminReportDto
  {

    public string SelName { get; set; }
    public string PrName { get; set; }
    public int numberOfStudents { get; set; }

    public int numberOfSuccess { get; set; }
    public int SuccessRate { get; set; }
  }
}
