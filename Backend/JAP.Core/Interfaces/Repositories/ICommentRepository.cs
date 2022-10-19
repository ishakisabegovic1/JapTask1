
using Microsoft.AspNetCore.Mvc;

namespace JAP.Core
{
  public interface ICommentRepository : IBaseRepository<JAP.Core.Comment>
  {
    Task<List<CommentDto>> GetAllComments();
    Task<List<CommentDto>> GetCommentsByStudentId(int studentId);

  }
}
