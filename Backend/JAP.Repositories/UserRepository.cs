using JAP.Common;
using JAP.Core;
using JAP.Database;
using Microsoft.EntityFrameworkCore;

namespace JAP.Repositories
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) : base(context)
    {
      _context = context;
    }

    public async Task<User> GetUserById(int id)
    {
      return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<User>> GetUsers()
    {
      return await _context.Users.ToListAsync();
    }
  }
}
