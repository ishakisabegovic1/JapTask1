using Api.DTOs;
using Api.Repositories.Comment;
using AutoMapper;

namespace Api.Services.Comment
{
  public class CommentService : ICommentService
  {
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
      _commentRepository = commentRepository;
      _mapper = mapper;
    }
    public async Task<CommentDto> AddComment(CommentDto commentDto)
    {
      var comment = new Entities.Comment
      {
        StudentId = commentDto.studentId,
        UserId = commentDto.userId,
        comment = commentDto.comment,
      };
      var addedComment = await _commentRepository.Add(comment);
      var addedCommentMap = _mapper.Map<CommentDto>(addedComment);
      return addedCommentMap;
    }

    public async Task<CommentDto> DeleteComment(int id)
    {
      var deletedComment = await _commentRepository.Delete(id);
      var deletedCommentMap = _mapper.Map<CommentDto>(deletedComment);
      return deletedCommentMap;
    }

    public async Task<List<CommentDto>> GetAllComments()
    {
      return await _commentRepository.GetAllComments();
    }

    public async Task<List<CommentDto>> GetCommentsByStudentId(int studentId)
    {
      return await _commentRepository.GetCommentsByStudentId(studentId);
    }
  }
}
