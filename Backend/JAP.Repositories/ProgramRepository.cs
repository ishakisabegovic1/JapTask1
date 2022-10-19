

using JAP.Core;
using JAP.Database;
using Microsoft.EntityFrameworkCore;

namespace JAP.Repositories
{
  public class ProgramRepository : BaseRepository<JAP.Core.Program>, IProgramRepository
  {
    private readonly AppDbContext _context;

    public ProgramRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<JAP.Core.Program> GetProgramById(int id)
    {
      var jap = await _context.Programs.SingleOrDefaultAsync(x => x.Id == id);
      return jap;
    }

    public async Task<List<JAP.Core.Program>> GetProgramsAsync()
    {
      var japs = await _context.Programs.ToListAsync();
      return japs;
    }
  }
}
