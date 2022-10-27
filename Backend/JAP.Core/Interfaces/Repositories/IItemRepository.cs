using JAP.Common;
using JAP.Core.DTOs;
using JAP.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Core.Interfaces.Repositories
{
  public interface IItemRepository : IBaseRepository<Item>
  {
    Task<List<ItemDto>> GetItems([FromQuery] ItemParams userParams);
    Task<ItemDto> GetItemById(int id);
  }
}
