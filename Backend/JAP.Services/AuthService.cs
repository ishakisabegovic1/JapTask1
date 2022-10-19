using JAP.Core;
using JAP.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JAP.Services
{
  public class AuthService : IAuthService
  {
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IStudentService _studentService;
    private readonly ITokenService _tokenService;
    private readonly IConfiguration _configuration;

    public AuthService(
      UserManager<User> userManager,
      RoleManager<Role> roleManager,
      IStudentService studentService,
      ITokenService tokenService,
      IConfiguration configuration)
    {
      _userManager = userManager;
      _roleManager = roleManager;
      _studentService = studentService;
      _tokenService = tokenService;
      _configuration = configuration;
    }
    public async Task<dynamic> Login(LoginDto loginDto)
    {
      var user = await _userManager.Users
        .Include(x => x.UserRoles)
        .ThenInclude(r => r.Role)
        .SingleOrDefaultAsync(x => x.UserName == loginDto.UserName);

      if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
      {

        var id = 0;

        if (user.UserRoles.Select(x => x.Role.Name).Contains("Student"))
        {
          id = await _studentService.GetStudentIdByUserId(user.Id);
        }

        var userToReturn = new UserDto
        {
          Username = user.UserName,
          Token = _tokenService.CreateToken(user),
          Roles = user.UserRoles.Select(x => x.Role.Name).First(),
          StudentId = id
        };

        return userToReturn;
      }

      return null;



    }
  }
}
