using Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services.Comment
{
  public interface ICommentService
  {
    Task<List<CommentDto>> GetAllComments();
    Task<List<CommentDto>> GetCommentsByStudentId(int studentId);
    Task<CommentDto> AddComment(CommentDto commentDto);
    Task<CommentDto> DeleteComment(int id);
  }
}
