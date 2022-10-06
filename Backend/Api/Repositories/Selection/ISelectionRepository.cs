using Api.DTOs;
using Api.Entities;
using Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Repositories.Selection
{
  public interface ISelectionRepository : IBaseRepository<Entities.Selection>
  {
    Task<List<SelectionDto>> GetSelectionsAsync([FromQuery] SelectionParams userParams);
    Task<SelectionDto> GetSelectionById(int id);
  }
}
