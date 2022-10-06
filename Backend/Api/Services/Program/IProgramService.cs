using Api.DTOs;

namespace Api.Services.Program
{
  public interface IProgramService
  {
    Task<List<ProgramDto>> GetProgramsAsync();

    Task<ProgramDto> GetProgramById(int id);
  }
}
