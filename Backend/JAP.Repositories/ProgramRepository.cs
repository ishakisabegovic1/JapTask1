

using AutoMapper;
using JAP.Core;
using JAP.Core.DTOs;
using JAP.Core.Entities;
using JAP.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JAP.Repositories
{
  public class ProgramRepository : BaseRepository<JAP.Core.Program>, IProgramRepository
  {
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    //private static int orderNumber = 0;

    public ProgramRepository(AppDbContext context, IMapper mapper) : base(context)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<JAP.Core.Program> GetProgramById(int id)
    {
      var jap = await _context.Programs.SingleOrDefaultAsync(x => x.Id == id);
      return jap;
    }

    public async Task<List<Program>> GetProgramsAsync()
    {
      var japs = await _context.Programs.ToListAsync();
      return japs;
    }

    public async Task<List<ProgramItemView>> GetItemsByProgramId(int programId)
    {
      var programItemList = await _context.ProgramItems
        .Include(x => x.Item)
        .Include(x => x.Program)
        .Where(x => x.ProgramId == programId)
        .OrderBy(x => x.OrderNumber)
        .ToListAsync();

      int order = 1;
      foreach (var l in programItemList)
      {
        l.OrderNumber = order++;
        _context.ProgramItems.Update(l);
      }


      var returnList = new List<ProgramItemView>();

      foreach (var item in programItemList)
      {
        returnList.Add(new ProgramItemView
        {
          Id = item.Id,
          ProgramId = item.ProgramId,
          ItemId = item.ItemId,
          ProgramName = item.Program.Name,
          ItemName = item.Item.Name,
          ExpHours = item.Item.ExpectedNumberOfHours,
          Url = item.Item.Url,
          OrderNumber = item.OrderNumber,
          Description = item.Item.Description
        });
      }

      return returnList;
    }

    public async Task<ProgramDto> AddProgram(ProgramDto req)
    {
      var addedProgram = _context.Programs.Add(_mapper.Map<Program>(req));
      await _context.SaveChangesAsync();
      return _mapper.Map<ProgramDto>(addedProgram);
    }

    public async Task<ProgramItemUpsert> AddItemToProgram(ProgramItemUpsert req)
    {
      var numberOfItems = _context.ProgramItems.Where(x => x.ProgramId == req.ProgramId).OrderBy(x => x.OrderNumber).Count();
      var list = _context.ProgramItems.Where(x => x.ProgramId == req.ProgramId).ToList();
      int order = 1;
      foreach (var l in list)
      {
        l.OrderNumber = order++;
        _context.ProgramItems.Update(l);
      }
      req.OrderNumber = order;
      _context.ProgramItems.Add(_mapper.Map<ProgramItem>(req));



      //dodati i za studenta
      //var selectionList = await _context.Selections.Where(x => x.ProgramId == req.ProgramId).ToListAsync();
      //foreach (var selection in selectionList)
      //{
      //  var students = await _context.Students.Where(x => x.SelectionId == selection.Id).ToListAsync();
      //  foreach (var st in students)
      //  {


      //  }
      //}



      await _context.SaveChangesAsync();
      return _mapper.Map<ProgramItemUpsert>(await _context.ProgramItems.FirstOrDefaultAsync(x => x.ProgramId == req.ProgramId && x.ItemId == req.ItemId));
    }




  }
}
