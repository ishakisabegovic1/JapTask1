using Api.Data;
using Api.DTOs;
using Api.Entities;
using Api.Services.Program;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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




  }
}
