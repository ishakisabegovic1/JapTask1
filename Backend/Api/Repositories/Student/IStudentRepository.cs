using Api.DTOs;
using Api.Entities;
using Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Repositories.Student
{
  public interface IStudentRepository : IBaseRepository<Entities.Student>
  {
    Task<List<StudentDto>> GetStudentsAsync([FromQuery] StudentParams userParams);
    Task<StudentDto> GetStudentById(int id);

    Task<List<StudentDto>> GetStudentsBySelectionId(int id);

    Task<int> GetStudentIdFromUser(int userId);

  }
}
