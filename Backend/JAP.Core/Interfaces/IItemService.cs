using JAP.Common;
using JAP.Core.DTOs;
using JAP.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Core.Interfaces
{
  public interface IItemService
  {
    Task<ItemDto> GetItemById(int id);
    Task<List<ItemDto>> GetItems([FromQuery] ItemParams userParams);
    Task<ItemUpsert> AddItem(ItemUpsert req);
    Task<ItemUpsert> EditItem(ItemUpsert req);
    Task DeleteItem(int id);


  }
}
