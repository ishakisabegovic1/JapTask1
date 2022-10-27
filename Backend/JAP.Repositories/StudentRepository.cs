using JAP.Common;
using JAP.Core;
using JAP.Database;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JAP.Core.DTOs;
using JAP.Core.Entities;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace JAP.Repositories
{
  public class StudentRepository : BaseRepository<Student>, IStudentRepository
  {
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public StudentRepository(AppDbContext context, IMapper mapper) : base(context)
    {
      _context = context;
      _mapper = mapper;
    }

    public override async Task<Student> Add(Student entity)
    {



      //_context.Set<Student>().Add(entity);
      _context.Students.Add(entity);
      await _context.SaveChangesAsync();


      return entity;
    }
    public async Task<List<ProgramItemStudentView>> GetStudentProgramById(int studentId)
    {
      var list = new List<ProgramItemStudentView>();
      var itemsList = await _context.ProgramItemStudents
        .Include(x => x.Student)
        .Include(x => x.ProgramItem)
        .ThenInclude(x => x.Item)
        .Where(x => x.StudentId == studentId)
        .ToListAsync();

      foreach (var item in itemsList)
      {
        list.Add(new ProgramItemStudentView
        {
          Id = item.Id,
          ProgramItemId = item.ProgramItemId,
          StudentId = item.StudentId,
          ItemName = item.ProgramItem.Item.Name,
          StudentName = item.Student.Name,
          Description = item.ProgramItem.Item.Description,
          Url = item.ProgramItem.Item.Url,
          OrderNumber = item.ProgramItem.OrderNumber,
          ExpHours = item.ProgramItem.Item.ExpectedNumberOfHours,
          StartDate = item.StartDate,
          EndDate = item.EndDate,
          DoneByCandidate = item.DoneByCandidate

        });
      }

      return list;
    }


    public async Task<StudentDto> AddItemsToStudent(StudentDto req)
    {

      var sel = _context.Selections.FirstOrDefault(x => x.Id == req.SelectionId);

      var programItems = _context.ProgramItems.Include(x => x.Item).Where(x => x.ProgramId == sel.ProgramId).ToList();

      var programItemStudents = _context.ProgramItemStudents.Where(x => x.StudentId == req.Id).ToList();

      programItems.OrderBy(x => x.OrderNumber);

      var stDate = new DateTime();
      var enDate = new DateTime();
      var prevDate = new DateTime();
      //prevDate = sel.StartDate;
      if (programItemStudents.Count() > 0)
      {
        var lastStudentItem = programItemStudents.Last();
        prevDate = lastStudentItem.EndDate;
      }
      else
        prevDate = sel.StartDate;

      foreach (var item in programItems)
      {

        if (programItemStudents.Where(x => x.ProgramItemId == item.Id).Count() == 0)
        {
          int daysCount = item.Item.ExpectedNumberOfHours / 8;


          if (item.OrderNumber == 1)
            stDate = sel.StartDate;
          else
            stDate = prevDate.AddDays(1);

          enDate = stDate.AddDays(daysCount);
          if (enDate > sel.EndDate) enDate = sel.EndDate;

          prevDate = enDate;

          _context.ProgramItemStudents.Add(new ProgramItemStudent
          {
            StudentId = req.Id,
            ProgramItemId = item.Id,
            DoneByCandidate = 0,
            StartDate = stDate,
            EndDate = enDate,
            StatusByCandidate = "NOT STARTED"
          });
        }
      }
      await _context.SaveChangesAsync();
      return req;
    }

    public async Task<StudentDto> GetStudentById(int id)
    {
      var student = await _context.Students.Include(m => m.Selection).Include(x => x.User).SingleOrDefaultAsync(x => x.Id == id);

      if (student == null) return null;

      //var studentDto = new StudentDto();

      var studentDto = _mapper.Map<StudentDto>(student);

      return studentDto;
    }

    public async Task<int> GetStudentIdFromUser(int userId)
    {
      var student = await _context.Students.FirstOrDefaultAsync(x => x.UserId == userId);

      var studentId = student.Id;

      return studentId;
    }

    public async Task<List<StudentDto>> GetStudentsAsync([FromQuery] StudentParams userParams)
    {
      var query = _context.Students.Include(m => m.Selection).Include(x => x.User).AsNoTracking().AsQueryable();

      if (userParams.nameFilter != null || userParams.statusFilter != null || userParams.selectionFilter != null)
      {
        query = query
                .Where(s => s.Name.ToLower().Contains(userParams.nameFilter.ToLower()))
                .Where(s => s.Status.ToLower().Contains(userParams.statusFilter.ToLower()))
                .Where(s => s.Selection.Name.ToLower().Contains(userParams.selectionFilter.ToLower()));
      }

      query = userParams.OrderBy switch
      {
        "Date" => query.OrderBy(s => s.DateOfBirth),
        "Name" => query.OrderBy(s => s.Name),
        "Status" => query.OrderBy(s => s.Status),
        "Selection" => query.OrderBy(s => s.Selection.StartDate),
        _ => query.OrderBy(s => s.Name)

      };

      var lista = _mapper.Map<List<StudentDto>>(query.ToList());
      if (lista == null) return null;

      return lista;
    }

    public async Task<List<StudentDto>> GetStudentsBySelectionId(int id)
    {
      var lista = _context.Students.Include(m => m.Selection).AsQueryable();

      var list = lista.Where(x => x.SelectionId == id).ToList();

      if (list == null) return null;

      var returnList = _mapper.Map<List<StudentDto>>(list);

      return returnList;
    }




  }
}
