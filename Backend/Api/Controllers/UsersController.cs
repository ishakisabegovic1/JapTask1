using Api.Data;
using JAP.Core;
using JAP.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
  public class UsersController : BaseApiController
  {
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
      return await _context.Users.Include(x => x.UserRoles).ToListAsync();
    }

  }
}
