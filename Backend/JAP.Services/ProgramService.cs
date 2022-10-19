
using AutoMapper;
using JAP.Core;

namespace JAP.Services
{
  public class ProgramService : IProgramService
  {
    private readonly IProgramRepository _programRepository;
    private readonly IMapper _mapper;

    public ProgramService(IProgramRepository programRepository, IMapper mapper)
    {
      _programRepository = programRepository;
      _mapper = mapper;
    }
    public async Task<ProgramDto> GetProgramById(int id)
    {
      var program = await _programRepository.GetProgramById(id);

      var programsMap = new ProgramDto
      {
        Name = program.Name,
        Id = program.Id
      };

      return programsMap;
    }

    public async Task<List<ProgramDto>> GetProgramsAsync()
    {
      var programs = await _programRepository.GetProgramsAsync();

      var programsMap = programs.Select(x => new ProgramDto
      {
        Name = x.Name,
        Id = x.Id
      }).ToList();

      return programsMap;
    }


  }
}
