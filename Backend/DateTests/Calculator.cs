using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTests
{
  public class Calculator
  {
    public void CalculateDates(DateTime prevDate, int expHours, out DateTime startDate, out DateTime endDate)
    {
      startDate = prevDate;

      endDate = prevDate
        .AddDays(expHours / 8)
        .AddHours(expHours % 8);

      if (endDate.DayOfWeek == DayOfWeek.Sunday)
        endDate = endDate.AddDays(1);
      if (endDate.DayOfWeek == DayOfWeek.Saturday)
        endDate = endDate.AddDays(2);
    }





  }
}
