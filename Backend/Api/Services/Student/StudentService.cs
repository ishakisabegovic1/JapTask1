using Api.DTOs;
using Api.Helpers;
using Api.Repositories.Student;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services.Student
{
  public class StudentService : IStudentService
  {
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IMapper mapper)
    {
      _studentRepository = studentRepository;
      _mapper = mapper;
    }

    public async Task<List<StudentDto>> GetStudentsAsync([FromQuery] StudentParams userParams)
    {
      return await _studentRepository.GetStudentsAsync(userParams);
    }
    public async Task<StudentDto> GetStudentById(int id)
    {
      return await _studentRepository.GetStudentById(id);
    }

    public async Task<List<StudentDto>> GetStudentsBySelectionId(int id)
    {
      return await _studentRepository.GetStudentsBySelectionId(id);
    }

    public async Task<StudentDto> AddStudent(StudentDto studentDto)
    {
      var student = new Entities.Student
      {
        Name = studentDto.Name,
        DateOfBirth = studentDto.DateOfBirth,
        Address = studentDto.Address,
        SelectionId = studentDto.SelectionId,
        Status = studentDto.Status,
      };

      var addedStudent = await _studentRepository.Add(student);
      var returnStudent = _mapper.Map<StudentDto>(addedStudent);
      return returnStudent;

    }

    public async Task<StudentDto> DeleteStudent(int id)
    {
      var deletedStudent = await _studentRepository.Delete(id);
      var deletedStudentMap = _mapper.Map<StudentDto>(deletedStudent);
      return deletedStudentMap;
    }

    public async Task<StudentDto> EditStudent(StudentDto studentDto)
    {
      var student = new Entities.Student
      {
        Id = studentDto.Id,
        Name = studentDto.Name,
        Address = studentDto.Address,
        DateOfBirth = studentDto.DateOfBirth,
        Status = studentDto.Status,
        SelectionId = studentDto.SelectionId

      };
      var updatedStudent = await _studentRepository.Update(student);
      if (updatedStudent == null) return null;
      var returnStudent = _mapper.Map<StudentDto>(updatedStudent);
      return returnStudent;
    }






  }
}
