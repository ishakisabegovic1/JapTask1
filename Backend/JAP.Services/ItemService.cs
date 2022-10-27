using AutoMapper;
using JAP.Common;
using JAP.Core.DTOs;
using JAP.Core.Entities;
using JAP.Core.Interfaces;
using JAP.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAP.Services
{
  public class ItemService : IItemService
  {
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public ItemService(IItemRepository itemRepository, IMapper mapper)
    {
      _itemRepository = itemRepository;
      _mapper = mapper;
    }
    public async Task<ItemUpsert> AddItem(ItemUpsert req)
    {
      _itemRepository.Add(_mapper.Map<Item>(req));
      return req;
    }


    public async Task DeleteItem(int id)
    {
      await _itemRepository.Delete(id);

    }

    public async Task<ItemUpsert> EditItem(ItemUpsert req)
    {
      var updatedItem = await _itemRepository.Update(_mapper.Map<Item>(req));
      return _mapper.Map<ItemUpsert>(updatedItem);
    }

    public async Task<ItemDto> GetItemById(int id)
    {
      return await _itemRepository.GetItemById(id);
    }

    public async Task<List<ItemDto>> GetItems([FromQuery] ItemParams userParams)
    {
      return await _itemRepository.GetItems(userParams);
    }
  }
}
