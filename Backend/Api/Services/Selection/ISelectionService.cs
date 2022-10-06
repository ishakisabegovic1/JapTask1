using Api.DTOs;
using Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services.Selection
{
  public interface ISelectionService
  {
    Task<List<SelectionDto>> GetSelectionsAsync([FromQuery] SelectionParams userParams);
    Task<SelectionDto> GetSelectionById(int id);
    Task<SelectionDto> AddSelection(SelectionDto selectionDto);
    Task<SelectionDto> EditSelection(SelectionDto selectionDto);
    Task<SelectionDto> DeleteSelection(int id);
  }
}
