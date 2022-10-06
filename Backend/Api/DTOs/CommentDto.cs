using Api.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.DTOs
{
  public class CommentDto
  {
    public int Id { get; set; }
    public int userId { get; set; }
    public int studentId { get; set; }
    public string comment { get; set; }
  }
}
