
using AutoMapper;
using JAP.Common;
using JAP.Core;
using Microsoft.AspNetCore.Mvc;


namespace JAP.Services
{
  public class SelectionService : ISelectionService
  {
    private readonly ISelectionRepository _selectionRepository;
    private readonly IMapper _mapper;

    public SelectionService(ISelectionRepository selectionRepository, IMapper mapper)
    {
      _selectionRepository = selectionRepository;
      _mapper = mapper;
    }
    public async Task<List<SelectionDto>> GetSelectionsAsync([FromQuery] SelectionParams userParams)
    {
      var selections = await _selectionRepository.GetSelectionsAsync(userParams);

      return selections;

    }

    public async Task<SelectionDto> GetSelectionById(int id)
    {
      var selection = await _selectionRepository.GetSelectionById(id);
      return selection;

    }

    public async Task<List<SelectionDto>> GetSelectionsByProgramId(int programId)
    {
      return await _selectionRepository.GetSelectionsByProgramId(programId);
    }

    public async Task<SelectionDto> AddSelection(SelectionDto selectionDto)
    {
      var selection = new Selection
      {
        Name = selectionDto.Name,
        StartDate = selectionDto.StartDate,
        EndDate = selectionDto.EndDate,
        ProgramId = selectionDto.ProgramId,
        Status = selectionDto.Status,
        //Program = selectionDto.Program
      };
      //var selection = _mapper.Map<Selection>(selectionDto);
      _selectionRepository.Add(selection);

      return selectionDto;
    }

    public async Task<SelectionDto> DeleteSelection(int id)
    {
      var deletedSelection = await _selectionRepository.Delete(id);
      var deletedSelectionMap = _mapper.Map<SelectionDto>(deletedSelection);
      return deletedSelectionMap;
    }

    public async Task<SelectionDto> EditSelection(SelectionDto selectionDto)
    {
      var selection = new Selection
      {
        Id = selectionDto.Id,
        Name = selectionDto.Name,
        StartDate = selectionDto.StartDate,
        EndDate = selectionDto.EndDate,
        ProgramId = selectionDto.ProgramId,
        Status = selectionDto.Status,
        //Program = selectionDto.Program
      };
      var updatedSelection = await _selectionRepository.Update(selection);
      if (updatedSelection == null) return null;
      return selectionDto;
    }


  }
}
