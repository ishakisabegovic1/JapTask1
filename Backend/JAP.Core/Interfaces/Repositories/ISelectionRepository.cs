
using JAP.Common;
using Microsoft.AspNetCore.Mvc;

namespace JAP.Core
{
  public interface ISelectionRepository : IBaseRepository<JAP.Core.Selection>
  {
    Task<List<SelectionDto>> GetSelectionsAsync([FromQuery] SelectionParams userParams);
    Task<SelectionDto> GetSelectionById(int id);
    Task<List<SelectionDto>> GetSelectionsByProgramId(int programId);
  }
}
