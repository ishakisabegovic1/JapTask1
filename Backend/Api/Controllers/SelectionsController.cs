
using Api.Controllers;
using Api.Extensions;
using JAP.Common;
using JAP.Core;
using Microsoft.AspNetCore.Mvc;


namespace JAP.Api.Controllers
{
  public class SelectionsController : BaseApiController
  {
    private readonly ISelectionService _selectionService;

    public SelectionsController(ISelectionService selectionService)
    {
      _selectionService = selectionService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedList<SelectionDto>>> GetAllSelections([FromQuery] SelectionParams userParams)
    {

      var lista = await _selectionService.GetSelectionsAsync(userParams);

      var list = await PagedList<SelectionDto>.CreateAsync(lista.AsQueryable(), userParams.PageNumber, userParams.PageSize);

      Response.AddPaginationHeader(list.CurrentPage, list.PageSize, list.TotalCount, list.TotalPages);

      return list;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SelectionDto>> GetSelectionById(int id)
    {
      var selection = await _selectionService.GetSelectionById(id);

      if (selection == null) return NotFound();

      return selection;
    }

    [HttpPost("add-selection")]
    public async Task<ActionResult> AddSelection(SelectionDto selectionDto)
    {
      if (!ValidateStatus(selectionDto.Status))
        return BadRequest("Invalid status");

      var selection = await _selectionService.AddSelection(selectionDto);
      if (selection == null)
        return NotFound();
      return Ok(selection);
    }

    [HttpPut("edit-selection/{id}")]
    public async Task<ActionResult> EditSelection(SelectionDto selectionDto)
    {
      if (!ValidateStatus(selectionDto.Status))
        return BadRequest("Invalid selection status");

      var selection = await _selectionService.EditSelection(selectionDto);
      if (selection == null) return NotFound();

      return Ok();
    }

    private bool ValidateStatus(string status)
    {
      if (status != "Active" && status != "Completed")
        return false;
      return true;
    }

    [HttpDelete("delete-selection/{id}")]
    public async Task<ActionResult<SelectionDto>> DeleteSelection(int id)
    {

      var selection = await _selectionService.DeleteSelection(id);

      return Ok(selection);
    }


  }
}
