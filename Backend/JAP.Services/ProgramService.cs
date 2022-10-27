
using AutoMapper;
using JAP.Core;
using JAP.Core.DTOs;

namespace JAP.Services
{
  public class ProgramService : IProgramService
  {
    private readonly IProgramRepository _programRepository;
    private readonly IMapper _mapper;
    private readonly ISelectionService _selectionService;
    private readonly IStudentService _studentService;

    public ProgramService(IProgramRepository programRepository,
      IMapper mapper,
      ISelectionService selectionService,
      IStudentService studentService)
    {
      _programRepository = programRepository;
      _mapper = mapper;
      _selectionService = selectionService;
      _studentService = studentService;
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

    public async Task<List<ProgramItemView>> GetItemsByProgramId(int programId)
    {
      return await _programRepository.GetItemsByProgramId(programId);
    }

    public async Task<ProgramDto> AddProgram(ProgramDto req)
    {
      var res = await _programRepository.Add(_mapper.Map<Program>(req));

      return _mapper.Map<ProgramDto>(res);
    }

    public async Task<ProgramDto> EditProgram(ProgramDto req)
    {
      var res = await _programRepository.Update(_mapper.Map<Program>(req));
      return _mapper.Map<ProgramDto>(res);
    }

    public async Task<ProgramItemUpsert> AddItemToProgram(ProgramItemUpsert req)
    {
      var res = await _programRepository.AddItemToProgram(req);
      var selections = await _selectionService.GetSelectionsByProgramId(res.ProgramId);
      foreach (var s in selections)
      {
        var students = await _studentService.GetStudentsBySelectionId(s.Id);
        foreach (var st in students)
        {
          await _studentService.AddItemsToStudent(st);
        }
      }
      return res;
    }

    public async Task<ProgramDto> DeleteProgram(int id)
    {
      var deletedProgram = await _programRepository.Delete(id);
      return _mapper.Map<ProgramDto>(deletedProgram);
    }


  }
}
