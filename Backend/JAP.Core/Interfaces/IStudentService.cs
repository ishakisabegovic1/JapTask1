
using JAP.Common;
using JAP.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace JAP.Core
{
  public interface IStudentService
  {
    Task<StudentDto> AddItemsToStudent(StudentDto req);
    Task<List<ProgramItemStudentView>> GetStudentProgramById(int studentId);
    Task<List<StudentDto>> GetStudentsAsync([FromQuery] StudentParams userParams);
    Task<StudentDto> GetStudentById(int id);
    Task<List<StudentDto>> GetStudentsBySelectionId(int id);
    Task<StudentUpdateDto> AddStudent(StudentUpdateDto studentDto);
    Task<StudentUpdateDto> EditStudent(StudentUpdateDto studentDto);
    Task<StudentDto> DeleteStudent(int id);

    Task<int> GetStudentIdByUserId(int userId);
  }
}
