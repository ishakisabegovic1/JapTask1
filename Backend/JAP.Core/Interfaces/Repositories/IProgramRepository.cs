

namespace JAP.Core
{
  public interface IProgramRepository : IBaseRepository<JAP.Core.Program>
  {
    Task<List<JAP.Core.Program>> GetProgramsAsync();
    Task<JAP.Core.Program> GetProgramById(int id);
  }
}
