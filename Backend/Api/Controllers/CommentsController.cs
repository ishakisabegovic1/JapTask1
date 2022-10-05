using Api.Data;
using Api.DTOs;
using Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    public class CommentsController : BaseApiController
    {
        private readonly AppDbContext _context;

        public CommentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetAllComments()
        {
            return await _context.UserStudents.ToListAsync();
        }

        [HttpGet("{studentId}")]
        public async Task<ActionResult<List<Comment>>> GetCommentsByStudentId(int studentId)
        {
            var list = await _context.UserStudents.Where(x => x.StudentId == studentId).ToListAsync();
            if (list.Count == 0) return BadRequest("No comments for that student");
            return list;
        }

        
        [HttpPost("add-comment/{studentId}")]
        public async Task<ActionResult> AddComment(CommentDto userStudentDto)
        {
            var student = await _context.Students.SingleOrDefaultAsync(x => x.Id == userStudentDto.studentId);
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == userStudentDto.userId);
            
            var comment = new Comment
            {
              
                StudentId = userStudentDto.studentId,
                UserId = userStudentDto.userId,
                comment = userStudentDto.comment,

            };

            _context.UserStudents.Add(comment);

            if (await _context.SaveChangesAsync() > 0) return Ok();

            return BadRequest("Failed to add comment");
        }

        [HttpDelete("delete-comment/{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var comment = await _context.UserStudents.SingleOrDefaultAsync(x => x.Id == id);
            if (comment == null) return BadRequest("This comment doesnt exist");
            _context.Remove(comment);
            if (await _context.SaveChangesAsync() > 0) return Ok();

            

            return BadRequest("Failed to delete comment");
        }
    }
}
