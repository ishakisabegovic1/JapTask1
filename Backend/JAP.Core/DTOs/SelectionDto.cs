using System.ComponentModel.DataAnnotations;

namespace JAP.Core
{
  public class SelectionDto
  {

    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public int ProgramId { get; set; }
    public string Program { get; set; }
  }
}
