
using AutoMapper;
using JAP.Core;
using JAP.Core.Interfaces;
using JAP.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Api.Controllers
{
  public class AuthController : BaseApiController
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IAuthService _authService;

    public AuthController(UserManager<User> userManager,
                          SignInManager<User> signInManager,
                          IAuthService authService)

    {
      _userManager = userManager;
      _signInManager = signInManager;
      _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
      var result = await _authService.Login(loginDto);
      if (result != null)
        return Ok(result);

      return BadRequest(result);
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(LoginDto loginDto)
    {
      //var user = _mapper.Map<User>(loginDto);

      //var result = await _userManager.CreateAsync(user, loginDto.Password);

      //var admin = new Admin
      //{
      //  UserId = user.Id
      //};

      //_context.Admins.Add(admin);
      //await _context.SaveChangesAsync();
      //if (!result.Succeeded) return BadRequest(result.Errors);
      //return Ok(user);
      return Ok();
    }



  }
}
