
using AutoMapper;
using JAP.Common;
using JAP.Core;
using JAP.Core.DTOs;
using JAP.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace JAP.Services
{
  public class StudentService : IStudentService
  {
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IEmailService _emailService;

    public StudentService(IStudentRepository studentRepository,
      IMapper mapper,
      UserManager<User> userManager,
      IEmailService emailService)
    {
      _studentRepository = studentRepository;
      _mapper = mapper;
      _userManager = userManager;
      _emailService = emailService;
    }

    public async Task<List<StudentDto>> GetStudentsAsync([FromQuery] StudentParams userParams)
    {
      return await _studentRepository.GetStudentsAsync(userParams);
    }
    public async Task<StudentDto> GetStudentById(int id)
    {
      return await _studentRepository.GetStudentById(id);
    }
    public async Task<List<ProgramItemStudentView>> GetStudentProgramById(int studentId)
    {
      return await _studentRepository.GetStudentProgramById(studentId);
    }

    public async Task<List<StudentDto>> GetStudentsBySelectionId(int id)
    {
      return await _studentRepository.GetStudentsBySelectionId(id);
    }

    public async Task<StudentDto> AddItemsToStudent(StudentDto req)
    {
      return await _studentRepository.AddItemsToStudent(req);
    }

    public async Task<StudentUpdateDto> AddStudent(StudentUpdateDto studentDto)
    {
      try
      {
        var user = new User()
        {
          UserName = ReplaceWhitespace(studentDto.Name.ToLower())
        };

        var result = await _userManager.CreateAsync(user, "Student1"); //password je Student1, mora biti uppercase i broj

        if (result.Succeeded)
        {
          await _userManager.AddToRoleAsync(user, "Student");

          var student = new Student
          {
            Name = studentDto.Name,
            DateOfBirth = studentDto.DateOfBirth,
            Address = studentDto.Address,
            SelectionId = studentDto.SelectionId,
            Status = studentDto.Status,
            UserId = user.Id
          };


          var addedStudent = await _studentRepository.Add(student);

          var addedStudentItems = await _studentRepository.AddItemsToStudent(_mapper.Map<StudentDto>(addedStudent));

          var returnStudent = _mapper.Map<StudentUpdateDto>(addedStudent);

          _emailService.SendPlainTextEmail("ishakisabegovic@gmail.com", user.UserName, "Student1");

          return returnStudent;
        }
        else
          return null;
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: ", ex);
        return null;
      }

    }

    public async Task<StudentDto> DeleteStudent(int id)
    {
      var deletedStudent = await _studentRepository.Delete(id);
      var deletedStudentMap = _mapper.Map<StudentDto>(deletedStudent);
      return deletedStudentMap;
    }

    public async Task<StudentUpdateDto> EditStudent(StudentUpdateDto studentDto)
    {
      var studentToUpdate = await _studentRepository.GetStudentById(studentDto.Id);

      var student = _mapper.Map<Student>(studentDto);

      student.Id = studentDto.Id;
      student.UserId = studentToUpdate.UserId;

      var updatedStudent = await _studentRepository.Update(student);
      if (updatedStudent == null) return null;

      var returnStudent = _mapper.Map<StudentUpdateDto>(updatedStudent);
      return returnStudent;
    }

    public async Task<int> GetStudentIdByUserId(int userId)
    {
      return await _studentRepository.GetStudentIdFromUser(userId);
    }

    private static readonly Regex sWhitespace = new Regex(@"\s+");
    public static string ReplaceWhitespace(string input)
    {
      return sWhitespace.Replace(input, "");
    }





  }

}
