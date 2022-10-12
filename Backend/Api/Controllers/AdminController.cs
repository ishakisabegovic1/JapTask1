using Api.Data;
using Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
  public class AdminController : BaseApiController
  {
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
      _context = context;
    }
    [HttpGet]
    public async Task<List<AdminReportDto>> GetAdminReport()
    {
      //return Ok();
      return _context.AdminReports.FromSqlRaw("spAdminReportTab").ToList();
    }

  }
}
