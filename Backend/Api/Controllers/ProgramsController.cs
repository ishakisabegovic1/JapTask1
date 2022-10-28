
using AutoMapper;
using JAP.Core.Entities;

using JAP.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JAP.Core;

namespace Api.Controllers
{

  public class ProgramsController : BaseApiController
  {

    private readonly IProgramService _programService;


    public ProgramsController(IProgramService programService)
    {
      _programService = programService;

    }

    [HttpGet]
    public async Task<ActionResult<List<ProgramDto>>> GetJaps()
    {
      return await _programService.GetProgramsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProgramDto>> GetJapById(int id)
    {
      return await _programService.GetProgramById(id);
    }
    [HttpGet("programItems/{programId}")]
    public async Task<ActionResult<List<ProgramItemView>>> GetItemsByProgramId(int programId)
    {
      var list = await _programService.GetItemsByProgramId(programId);
      if (list == null) return BadRequest();
      return Ok(list);
    }

    [HttpPost("add-program")]
    public async Task<ActionResult<ProgramDto>> AddProgram([FromBody] ProgramDto req)
    {
      var res = await _programService.AddProgram(req);
      if (res == null) return BadRequest();
      return Ok(res);
    }


    [HttpPost("add-item")]
    public async Task<ActionResult<ProgramItemUpsert>> AddItemToProgram([FromBody] ProgramItemUpsert req)
    {
      return Ok(await _programService.AddItemToProgram(req));
    }

    [HttpPut("edit-program/{id}")]
    public async Task<ActionResult<ProgramDto>> EditProgram(ProgramDto req)
    {
      return Ok(await _programService.EditProgram(req));
    }

    [HttpPut("edit-program-item/{id}")]
    public async Task<ActionResult<ProgramItemUpsert>> EditProgramItem(ProgramItemUpsert req, int newOrderNumber)
    {
      return Ok(await _programService.EditProgramItem(req, newOrderNumber));
    }

    [HttpDelete("delete-program/{id}")]
    public async Task<ActionResult<ProgramDto>> DeleteProgram(int id)
    {
      var deletedProgram = await _programService.DeleteProgram(id);
      return Ok(deletedProgram);
    }

    [HttpDelete("delete-programItem")]
    public async Task<ActionResult<ProgramItemUpsert>> DeleteProgramItem(int id)
    {
      // implementirati
      return Ok();
    }





  }
}
