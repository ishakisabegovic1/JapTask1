
using JAP.Core;
using JAP.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
  public class AdminReportController : BaseApiController
  {
    private readonly AppDbContext _context;

    public AdminReportController(AppDbContext context)
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
