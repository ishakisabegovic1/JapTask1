using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
  public class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    private readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<T> Add(T entity)
    {
      _context.Set<T>().Add(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public async Task<T> Delete(int id)
    {
      var entity = await _context.Set<T>().FindAsync(id);
      if (entity == null) return entity;

      _context.Set<T>().Remove(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public async Task<T> Update(T entity)
    {
      _context.Set<T>().Update(entity);
      await _context.SaveChangesAsync();
      return entity;
    }
  }
}
