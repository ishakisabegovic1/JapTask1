using JAP.Common;
using JAP.Core;
using JAP.Database;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
