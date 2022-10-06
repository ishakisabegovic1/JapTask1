using Api.DTOs;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Repositories.Comment
{
  public interface ICommentRepository : IBaseRepository<Entities.Comment>
  {
    Task<List<CommentDto>> GetAllComments();
    Task<List<CommentDto>> GetCommentsByStudentId(int studentId);

  }
}
