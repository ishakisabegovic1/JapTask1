using AutoMapper;
using JAP.Common;
using JAP.Core.DTOs;
using JAP.Core.Entities;
using JAP.Core.Interfaces.Repositories;
using JAP.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JAP.Repositories
{
  public class ItemRepository : BaseRepository<Item>, IItemRepository
  {
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ItemRepository(AppDbContext context, IMapper mapper) : base(context)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<ItemDto> GetItemById(int id)
    {
      var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);

      return _mapper.Map<ItemDto>(item);
    }

    public async Task<List<ItemDto>> GetItems([FromQuery] ItemParams userParams)
    {

      //var list = await _context.Items.ToListAsync();

      var query = _context.Items.AsQueryable();

      if (userParams.nameFilter != null || userParams.descFilter != null || userParams.urlFilter != null)
      {
        query = query
                .Where(s => s.Name.ToLower().Contains(userParams.nameFilter.ToLower()))
                .Where(s => s.Description.ToLower().Contains(userParams.descFilter.ToLower()))
                .Where(s => s.Url.ToLower().Contains(userParams.urlFilter.ToLower()));

      }

      query = userParams.OrderBy switch
      {

        "Name" => query.OrderBy(s => s.Name),
        "Description" => query.OrderBy(s => s.Description),
        "Url" => query.OrderBy(s => s.Url),
        "Hours" => query.OrderBy(s => s.ExpectedNumberOfHours),
        _ => query.OrderBy(s => s.Name)

      };
      var list = query.ToList();

      var returnList = new List<ItemDto>();

      foreach (var l in list)
      {
        returnList.Add(_mapper.Map<ItemDto>(l));
      }

      return returnList;
    }
  }
}
