
using JAP.Core.DTOs;

namespace JAP.Core
{
  public interface IProgramService
  {
    Task<List<ProgramDto>> GetProgramsAsync();
    Task<ProgramDto> GetProgramById(int id);
    Task<ProgramDto> AddProgram(ProgramDto req);
    Task<List<ProgramItemView>> GetItemsByProgramId(int programId);

    Task<ProgramItemUpsert> AddItemToProgram(ProgramItemUpsert req);
    Task<ProgramDto> EditProgram(ProgramDto req);
    Task<ProgramItemUpsert> EditProgramItem(ProgramItemUpsert req, int newOrderNumber);
    Task<ProgramDto> DeleteProgram(int id);
  }
}
