using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.User
{
  public class UserRepository : BaseRepository<Entities.User>, IUserRepository
  {
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<Entities.User> GetUserById(int id)
    {
      return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Entities.User>> GetUsers()
    {
      return await _context.Users.ToListAsync();
    }
  }
}
