
namespace JAP.Core
{
  public interface IProgramService
  {
    Task<List<ProgramDto>> GetProgramsAsync();

    Task<ProgramDto> GetProgramById(int id);
  }
}
