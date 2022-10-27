using JAP.Core;
using JAP.Core.Interfaces;

using JAP.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Services
{
  public class HangfireService : IHangfireService
  {
    private readonly AppDbContext _context;
    private readonly ISelectionService _selectionService;
    private readonly IEmailService _emailService;

    public HangfireService(
      AppDbContext context,
      ISelectionService selectionService,
      IEmailService emailService)
    {
      _context = context;
      _selectionService = selectionService;
      _emailService = emailService;
    }

    public async Task CheckDate()
    {
      DateTime date = DateTime.Now;

      var selections = await _context.Selections.Where(x => x.EndDate == date).ToListAsync();
      var report = _context.AdminReports.FromSqlRaw("spAdminReportTab").ToList();
      foreach (var sel in selections)
      {
        var sendReport = report.First(x => x.SelName == sel.Name);
        _emailService.SendSelectionReportEmail(sendReport);
      }
    }
  }
}
