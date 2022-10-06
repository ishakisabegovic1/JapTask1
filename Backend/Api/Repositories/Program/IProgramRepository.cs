using Api.Entities;

namespace Api.Repositories.Program
{
  public interface IProgramRepository : IBaseRepository<Api.Entities.Program>
  {
    Task<List<Api.Entities.Program>> GetProgramsAsync();
    Task<Api.Entities.Program> GetProgramById(int id);
  }
}
