
using Api.Extensions;
using JAP.Common;
using JAP.Core;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
  public class StudentsController : BaseApiController
  {
    private readonly IStudentService _studentService;
    private readonly IEmailService _emailService;

    public StudentsController(IStudentService studentService, IEmailService emailService)
    {
      _studentService = studentService;
      _emailService = emailService;
    }

    //[Authorize]
    [HttpGet]
    public async Task<ActionResult<PagedList<StudentDto>>> GetStudents([FromQuery] StudentParams userParams)
    {

      var lista = await _studentService.GetStudentsAsync(userParams);

      var list = await PagedList<StudentDto>.CreateAsync(lista.AsQueryable(), userParams.PageNumber, userParams.PageSize);

      Response.AddPaginationHeader(list.CurrentPage, list.PageSize, list.TotalCount, list.TotalPages);

      return Ok(list);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDto>> GetStudentById(int id)
    {
      var student = await _studentService.GetStudentById(id);

      if (student == null) return NotFound("Student doesnt exist.");

      return Ok(student);
    }

    [HttpGet("selectionStudents/{id}")]
    public async Task<ActionResult<List<StudentDto>>> GetStudentsBySelectionId(int id)
    {
      var returnList = await _studentService.GetStudentsBySelectionId(id);

      return Ok(returnList);
    }


    [HttpPost("add-student")]
    public async Task<ActionResult<StudentUpdateDto>> AddStudent(StudentUpdateDto studentDto)
    {
      if (!ValidateStatus(studentDto.Status))
        return BadRequest("Invalid student status");

      var addedStudent = await _studentService.AddStudent(studentDto);
      _emailService.SendPlainTextEmail("ishakisabegovic@gmail.com", studentDto.Name.Trim().ToLower(), "Student1");

      return Ok(addedStudent);
    }

    [HttpPut("edit-student/{id}")]
    public async Task<ActionResult<StudentDto>> EditStudent(StudentUpdateDto studentDto)
    {
      if (!ValidateStatus(studentDto.Status))
        return BadRequest("Invalid student status");

      var student = await _studentService.EditStudent(studentDto);

      if (student == null) return NotFound("Student doesnt exist");

      return Ok(student);

    }

    [HttpDelete("delete-student/{id}")]
    public async Task<ActionResult<StudentDto>> DeleteStudent(int id)
    {

      var student = await _studentService.DeleteStudent(id);
      return Ok(student);

    }

    private bool ValidateStatus(string status)
    {
      if (status != "InProgress" && status != "Failed" && status != "Success" && status != "Extended")
        return false;
      return true;
    }
  }
}
