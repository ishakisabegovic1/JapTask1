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
using System.Xml.Linq;

namespace Api.Controllers
{
    public class StudentsController : BaseApiController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<PagedList<StudentDto>>> GetStudents([FromQuery]StudentParams userParams)
        {
            var query = _context.Students.AsNoTracking().AsQueryable();
           
            if(userParams.nameFilter != null || userParams.statusFilter != null || userParams.selectionFilter != null)
            {
                query = query
                        .Where(s => s.Name.ToLower().Contains(userParams.nameFilter.ToLower()))
                        .Where(s => s.StudentStatus.ToLower().Contains(userParams.statusFilter.ToLower()))
                        .Where(s => s.Selection.Name.ToLower().Contains(userParams.selectionFilter.ToLower()));
            }

            query = userParams.OrderBy switch
            {
                "Date" => query.OrderBy(s=> s.DateOfBirth),
                "Name" => query.OrderBy(s=>s.Name),
                "Status" => query.OrderBy(s=>s.StudentStatus),
                "Selection" => query.OrderBy(s=>s.Selection.StartDate),
                _ => query.OrderBy(s => s.Name)

            };


            var lista = query.Select(x=> new StudentDto
            {
                Id= x.Id,
                Name = x.Name,
                DateOfBirth = x.DateOfBirth,
                Address = x.Address,
                StudentStatus = x.StudentStatus,
                SelectionId=x.SelectionId,
                Selection = x.Selection.Name

            });

            var list = await PagedList<StudentDto>.CreateAsync(lista , userParams.PageNumber, userParams.PageSize);

            Response.AddPaginationHeader(list.CurrentPage, list.PageSize, list.TotalCount, list.TotalPages);

            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(x => x.Id == id);
            var selection = await _context.Selections.SingleOrDefaultAsync(x => x.Id == student.SelectionId);
            var studentDto = new StudentDto();
            if (student == null) return BadRequest("Student doesnt exist.");
            studentDto.Id = student.Id;
            studentDto.Name = student.Name;
            studentDto.DateOfBirth = student.DateOfBirth;
            studentDto.Address = student.Address;
            studentDto.StudentStatus = student.StudentStatus;
            studentDto.SelectionId = student.SelectionId;
            studentDto.Selection = selection.Name;

            return studentDto;
        }

        [HttpGet("selectionStudents/{id}")]
        public async Task<ActionResult<List<StudentDto>>> GetStudentsBySelectionId(int id)
        {
            var lista = _context.Students.AsQueryable();

            var list = lista.Where(x => x.SelectionId == id).Select(x => new StudentDto
            {
                Id = x.Id,
                Name = x.Name,
                DateOfBirth = x.DateOfBirth,
                Address = x.Address,
                StudentStatus = x.StudentStatus,
                SelectionId = x.SelectionId,
                Selection = x.Selection.Name
            }).ToList();

            
            return list;
        }


        [HttpPost("add-student")]
        public async Task<ActionResult> AddStudent(StudentDto studentDto)
        {
            var Status = studentDto.StudentStatus;
            
            if (!ValidateStatus(Status))
                return BadRequest("Invalid student status");


            var student = new Student
            {
                Name = studentDto.Name,
                DateOfBirth = studentDto.DateOfBirth,
                Address = studentDto.Address,
                SelectionId = studentDto.SelectionId,
                StudentStatus = studentDto.StudentStatus,
                
            };

             _context.Students.Add(student);
            if( await _context.SaveChangesAsync() > 0) return Ok();
            return Ok();
        }

        [HttpPut("edit-student/{id}")]
        public async Task<ActionResult<StudentDto>> EditStudent(StudentDto studentDto)
        {

            var student = await _context.Students.SingleOrDefaultAsync(x => x.Id == studentDto.Id);

            if (student == null) return BadRequest("Student doesnt exist");

            var selectionName = await _context.Selections.SingleOrDefaultAsync(x => x.Id == studentDto.SelectionId);

            //if (selection == null) return BadRequest("That selection doesnt exist");

            if (!ValidateStatus(studentDto.StudentStatus))
                return BadRequest("Invalid student status");

            student.Name = studentDto.Name;
            student.Address = studentDto.Address;
            student.DateOfBirth = studentDto.DateOfBirth;
            student.StudentStatus = studentDto.StudentStatus;
            student.SelectionId = studentDto.SelectionId;
            student.Selection = selectionName;
            

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return Ok();

        }

        private bool ValidateStatus(string status)
        {
            if (status != "InProgress" && status != "Failed" && status != "Success" && status != "Extended")
                return false;
            return true;
        }

        [HttpDelete("delete-student/{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(x => x.Id == id);
            _context.Students.Remove(student);

            if (await _context.SaveChangesAsync() > 0)
                return Ok();

            return BadRequest("Failed to delete selection");

        }
    }
}
