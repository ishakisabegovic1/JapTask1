
using AutoMapper;
using JAP.Core;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
  public class CommentsController : BaseApiController
  {
    private readonly ICommentService _commentService;
    private readonly IMapper _mapper;

    public CommentsController(ICommentService commentService, IMapper mapper)
    {
      _commentService = commentService;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<CommentDto>>> GetAllComments()
    {
      return Ok(await _commentService.GetAllComments());
    }

    [HttpGet("{studentId}")]
    public async Task<ActionResult<List<Comment>>> GetCommentsByStudentId(int studentId)
    {
      return Ok(await _commentService.GetCommentsByStudentId(studentId));
    }


    [HttpPost("add-comment/{studentId}")]
    public async Task<ActionResult<CommentDto>> AddComment(CommentDto commentDto)
    {
      var addedComment = await _commentService.AddComment(commentDto);
      var addedCommentMap = _mapper.Map<CommentDto>(addedComment);
      return Ok(addedCommentMap);

    }

    [HttpDelete("delete-comment/{id}")]
    public async Task<ActionResult<CommentDto>> DeleteComment(int id)
    {
      var deletedComment = await _commentService.DeleteComment(id);
      var deletedCommentMap = _mapper.Map<CommentDto>(deletedComment);
      return Ok(deletedCommentMap);

    }
  }
}
