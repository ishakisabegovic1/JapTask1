
using AutoMapper;
using JAP.Core;
using JAP.Database;
using Microsoft.EntityFrameworkCore;

namespace JAP.Repositories
{
  public class CommentRepository : BaseRepository<JAP.Core.Comment>, ICommentRepository
  {
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CommentRepository(AppDbContext context, IMapper mapper) : base(context)
    {
      _context = context;
      _mapper = mapper;
    }
    public async Task<List<CommentDto>> GetAllComments()
    {
      var comments = await _context.Comments.ToListAsync();
      var commentsMapped = _mapper.Map<List<CommentDto>>(comments);
      return commentsMapped;
    }
    public async Task<List<CommentDto>> GetCommentsByStudentId(int studentId)
    {
      var comments = await _context.Comments.Where(x => x.StudentId == studentId).ToListAsync();
      var commentsMapped = _mapper.Map<List<CommentDto>>(comments);
      return commentsMapped;

    }
  }
}
