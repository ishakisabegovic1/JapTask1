using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Program
{
  public class ProgramRepository : BaseRepository<Entities.Program>, IProgramRepository
  {
    private readonly AppDbContext _context;

    public ProgramRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<Entities.Program> GetProgramById(int id)
    {
      var jap = await _context.Programs.SingleOrDefaultAsync(x => x.Id == id);
      return jap;
    }

    public async Task<List<Entities.Program>> GetProgramsAsync()
    {
      var japs = await _context.Programs.ToListAsync();
      return japs;
    }
  }
}
