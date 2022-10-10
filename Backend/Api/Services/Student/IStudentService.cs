using Api.DTOs;
using Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services.Student
{
  public interface IStudentService
  {
    Task<List<StudentDto>> GetStudentsAsync([FromQuery] StudentParams userParams);
    Task<StudentDto> GetStudentById(int id);
    Task<List<StudentDto>> GetStudentsBySelectionId(int id);
    Task<StudentUpdateDto> AddStudent(StudentUpdateDto studentDto);
    Task<StudentUpdateDto> EditStudent(StudentUpdateDto studentDto);
    Task<StudentDto> DeleteStudent(int id);

    Task<int> GetStudentIdByUserId(int userId);
  }
}
