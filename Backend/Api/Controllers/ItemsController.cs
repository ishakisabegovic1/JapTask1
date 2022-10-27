using Api.Controllers;
using Api.Extensions;
using AutoMapper;
using JAP.Common;
using JAP.Core;
using JAP.Core.DTOs;
using JAP.Core.Entities;
using JAP.Core.Interfaces;
using JAP.Core.Interfaces.Repositories;
using JAP.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace JAP.Api.Controllers
{
  public class ItemsController : BaseApiController
  {
    private readonly IItemService _itemService;
    private readonly IMapper _mapper;

    public ItemsController(IItemService itemService, IMapper mapper)
    {
      _itemService = itemService;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<PagedList<ItemDto>>> GetItems([FromQuery] ItemParams itemParams)
    {
      var lista = await _itemService.GetItems(itemParams);

      var list = await PagedList<ItemDto>.CreateAsync(lista.AsQueryable(), itemParams.PageNumber, itemParams.PageSize);

      Response.AddPaginationHeader(list.CurrentPage, list.PageSize, list.TotalCount, list.TotalPages);

      return list;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ItemDto>> GetItemById(int id)
    {
      return Ok(await _itemService.GetItemById(id));
    }

    [HttpPost("add-item")]
    public async Task<ActionResult<ItemUpsert>> AddItem(ItemUpsert req)
    {
      var addedItem = await _itemService.AddItem(req);

      if (addedItem == null) return BadRequest();

      return Ok(addedItem);
    }
    [HttpPut("edit-item/{id}")]
    public async Task<ActionResult<ItemUpsert>> EditItem(ItemUpsert req)
    {
      var editedItem = await _itemService.EditItem(req);
      if (editedItem == null) return BadRequest();
      return Ok(editedItem);
    }

    [HttpDelete("delete-item/{id}")]
    public async Task<ActionResult> DeleteItem(int id)
    {
      await _itemService.DeleteItem(id);
      return Ok();
    }
  }
}
