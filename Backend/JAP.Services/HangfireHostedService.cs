using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;

namespace JAP.Services
{
  public class HangfireHostedService : IHostedService
  {
    public async Task StartAsync(CancellationToken cancellationToken)
    {
      RecurringJob.AddOrUpdate<HangfireService>(service => service.CheckDate(), "0 17 * * *");
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
