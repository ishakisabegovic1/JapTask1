
using JAP.Common;
using Microsoft.AspNetCore.Mvc;

namespace JAP.Core
{
  public interface ISelectionService
  {
    Task<List<SelectionDto>> GetSelectionsAsync([FromQuery] SelectionParams userParams);
    Task<SelectionDto> GetSelectionById(int id);
    Task<SelectionDto> AddSelection(SelectionDto selectionDto);
    Task<SelectionDto> EditSelection(SelectionDto selectionDto);
    Task<SelectionDto> DeleteSelection(int id);
    Task<List<SelectionDto>> GetSelectionsByProgramId(int programId);
  }
}
