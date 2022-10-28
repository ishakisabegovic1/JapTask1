

using JAP.Core.DTOs;
using JAP.Core.Entities;

namespace JAP.Core
{
  public interface IProgramRepository : IBaseRepository<JAP.Core.Program>
  {
    Task<List<JAP.Core.Program>> GetProgramsAsync();
    Task<JAP.Core.Program> GetProgramById(int id);
    Task<List<ProgramItemView>> GetItemsByProgramId(int programId);

    Task<ProgramDto> AddProgram(ProgramDto req);
    Task<ProgramItemUpsert> AddItemToProgram(ProgramItemUpsert req);
    Task<ProgramItemUpsert> EditProgramItem(ProgramItemUpsert req, int newOrderNumber);
    Task OrderItems(int programId);
  }
}
