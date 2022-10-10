using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
  public class StudentUpdateDto
  {
    public int Id { get; set; }

    public string Name { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public string Address { get; set; }

    public string Status { get; set; }


    public int SelectionId { get; set; }
  }
}
