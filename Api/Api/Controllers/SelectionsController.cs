using Api.Data;
using Api.DTOs;
using Api.Entities;
using Api.Extensions;
using Api.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace Api.Controllers
{
    public class SelectionsController : BaseApiController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SelectionsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<SelectionDto>>> GetAllSelections([FromQuery] SelectionParams userParams)
        {
                
            var query = _context.Selections.AsNoTracking().AsQueryable();

            if (userParams.nameFilter != null || userParams.statusFilter != null || userParams.japFilter != null)
            {
                query = query
                        .Where(s => s.Name.ToLower().Contains(userParams.nameFilter.ToLower()))
                        .Where(s => s.Status.ToLower().Contains(userParams.statusFilter.ToLower()))
                        .Where(s => s.Jap.Name.ToLower().Contains(userParams.japFilter.ToLower()));
                if (userParams.dateFilter != null)
                    query = query.Where(s => DateTime.Compare(s.StartDate, userParams.dateFilter) >= 0);
                if (userParams.endDateFilter != null)
                    query = query.Where(s => DateTime.Compare(s.EndDate, userParams.endDateFilter) <= 0);
            }

            query = userParams.OrderBy switch
            {   
                "StartDate" => query.OrderBy(s => s.StartDate), 
                "EndDate" => query.OrderBy(s => s.EndDate),
                "Name" => query.OrderBy(s => s.Name),
                "Status" => query.OrderBy(s => s.Status),
                "Jap" => query.OrderBy(s => s.Jap.Name),
                _ => query.OrderBy(s => s.Name)

            };

            var lista = query.Select(x => new SelectionDto
            {
                Id = x.Id,
                Name = x.Name,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Status = x.Status,
                JapId = x.JapId,
                Jap = x.Jap.Name

            });

            var list = await PagedList<SelectionDto>.CreateAsync(lista, userParams.PageNumber, userParams.PageSize);

            Response.AddPaginationHeader(list.CurrentPage, list.PageSize, list.TotalCount, list.TotalPages);

            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SelectionDto>> GetSelectionById(int id)
        {
            var sel =  await _context.Selections.SingleOrDefaultAsync(x => x.Id == id);
            if (sel == null) return BadRequest("This selection doesnt exits");
            var jap = await _context.Japs.SingleOrDefaultAsync(x => x.Id == sel.JapId);
            var selDto = new SelectionDto();
            //_mapper.Map(sel, selDto);            
            selDto.Id = sel.Id;
            selDto.Name = sel.Name;
            selDto.StartDate = sel.StartDate;
            selDto.EndDate = sel.EndDate;
            selDto.Status = sel.Status;
            selDto.JapId = sel.JapId;
            selDto.Jap = jap.Name;
            

            return selDto;
        }

        [HttpPost("add-selection")]
        public async Task<ActionResult> AddSelection(SelectionDto selectionDto)
        {

            if (!ValidateStatus(selectionDto.Status))
                return BadRequest("Invalid status");

            var jap = await _context.Japs.SingleOrDefaultAsync(x => x.Id == selectionDto.JapId);

             var selection = new Selection
             {
                Name = selectionDto.Name,
                StartDate = selectionDto.StartDate,
                EndDate = selectionDto.EndDate,
                JapId = selectionDto.JapId,
                Status = selectionDto.Status,
                //Jap = jap
             };

            _context.Selections.Add(selection);

            if (await _context.SaveChangesAsync() > 0)
                return Ok();

            return BadRequest("Failed to add selection");
        }

        [HttpPut("edit-selection/{id}")]
        public async Task<ActionResult> EditSelection(SelectionDto selectionDto)
        {
            var selection = await _context.Selections.SingleOrDefaultAsync(x => x.Id == selectionDto.Id);
            
            if (!ValidateStatus(selectionDto.Status))
                return BadRequest("Invalid selection status");

            selection.Name = selectionDto.Name;
            selection.StartDate = selectionDto.StartDate;
            selection.EndDate = selectionDto.EndDate;
            selection.Status = selectionDto.Status;
            selection.JapId = selectionDto.JapId;
           

            _context.Selections.Update(selection);

            if(await _context.SaveChangesAsync() > 0)
            return Ok();

            return BadRequest("Failed to update selection");

        }

        private bool ValidateStatus(string status)
        {
            if (status != "Active" && status != "Completed")
                return false;
            return true;
        }

        [HttpDelete("delete-selection/{id}")]
        public async Task<ActionResult<bool>> DeleteSelection(int id)
        {
            var selection = await _context.Selections.SingleOrDefaultAsync(x => x.Id == id);
             _context.Selections.Remove(selection);

            return await _context.SaveChangesAsync() > 0;

            return BadRequest("Failed to delete selection");
    
        }


    }
}
