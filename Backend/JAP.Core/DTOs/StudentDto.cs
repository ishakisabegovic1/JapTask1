using System.ComponentModel.DataAnnotations;

namespace JAP.Core
{
  public class StudentDto
  {

    public int Id { get; set; }

    public string Name { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public string Address { get; set; }

    public string Status { get; set; }


    public int SelectionId { get; set; }

    public string Selection { get; set; }

    public int UserId { get; set; }
  }
}
