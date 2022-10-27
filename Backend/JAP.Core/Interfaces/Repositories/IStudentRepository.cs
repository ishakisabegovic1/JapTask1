
using JAP.Common;
using JAP.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace JAP.Core
{
  public interface IStudentRepository : IBaseRepository<JAP.Core.Student>
  {
    Task<StudentDto> AddItemsToStudent(StudentDto req);
    Task<List<ProgramItemStudentView>> GetStudentProgramById(int studentId);
    Task<List<StudentDto>> GetStudentsAsync([FromQuery] StudentParams userParams);
    Task<StudentDto> GetStudentById(int id);

    Task<List<StudentDto>> GetStudentsBySelectionId(int id);

    Task<int> GetStudentIdFromUser(int userId);

  }
}
