using Api.Data;
using Api.DTOs;
using Api.Entities;
using Api.Extensions;
using Api.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Linq;
using System.Xml.Linq;
using Api.Services.Student;

namespace Api.Controllers
{
  public class StudentsController : BaseApiController
  {
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
      _studentService = studentService;
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
    public async Task<ActionResult<StudentDto>> AddStudent(StudentDto studentDto)
    {
      if (!ValidateStatus(studentDto.Status))
        return BadRequest("Invalid student status");

      var addedStudent = await _studentService.AddStudent(studentDto);

      return Ok(addedStudent);
    }

    [HttpPut("edit-student/{id}")]
    public async Task<ActionResult<StudentDto>> EditStudent(StudentDto studentDto)
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
