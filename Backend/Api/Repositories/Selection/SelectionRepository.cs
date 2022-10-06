using Api.Data;
using Api.DTOs;
using Api.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Selection
{
  public class SelectionRepository : BaseRepository<Entities.Selection>, ISelectionRepository
  {
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public SelectionRepository(AppDbContext context, IMapper mapper) : base(context)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<SelectionDto> GetSelectionById(int id)
    {
      var selection = await _context.Selections
        .Include(x => x.Students)
        .Include(x => x.Jap)
        .SingleOrDefaultAsync(x => x.Id == id);

      var selectionMap = _mapper.Map<SelectionDto>(selection);

      return selectionMap;

    }

    public async Task<List<SelectionDto>> GetSelectionsAsync([FromQuery] SelectionParams userParams)
    {
      var query = _context.Selections
        .Include(x => x.Students)
        .Include(x => x.Jap)
        .AsQueryable();

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

      var lista = _mapper.Map<List<SelectionDto>>(query.ToList());

      return lista;



    }


  }
}
