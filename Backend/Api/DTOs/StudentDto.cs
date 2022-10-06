using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
  public class StudentDto
  {

    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public string Address { get; set; }
    [Required]
    public string Status { get; set; }

    [Required]
    public int SelectionId { get; set; }

    public string Selection { get; set; }


  }
}
