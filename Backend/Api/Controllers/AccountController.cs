using Api.Data;
using Api.DTOs;
using Api.Entities;
using Api.Services.Student;
using Api.Services.Token;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Api.Controllers
{
  public class AccountController : BaseApiController
  {
    private readonly AppDbContext _context;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    private readonly RoleManager<Role> _roleManager;
    private readonly IStudentService _studentService;
    private readonly UserManager<User> _userManager;

    public AccountController(AppDbContext context, ITokenService tokenService, UserManager<User> userManager,
      SignInManager<User> signInManager, IMapper mapper, RoleManager<Role> roleManager, IStudentService studentService)
    {
      _context = context;
      _tokenService = tokenService;
      _signInManager = signInManager;
      _mapper = mapper;
      _roleManager = roleManager;
      _studentService = studentService;
      _userManager = userManager;


    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
      var user = await _userManager.Users.Include(x => x.UserRoles)
        .ThenInclude(r => r.Role)

        .SingleOrDefaultAsync(x => x.UserName == loginDto.UserName);

      if (user == null) return Unauthorized("Invalid username");

      var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

      if (!result.Succeeded) return Unauthorized();

      // var password = await _context.Users.SingleOrDefaultAsync(x => x.Password == loginDto.Password);

      //  if (password == null) return Unauthorized("Invalid password");
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

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(LoginDto loginDto)
    {
      var user = _mapper.Map<User>(loginDto);

      var result = await _userManager.CreateAsync(user, loginDto.Password);

      var admin = new Admin
      {
        UserId = user.Id
      };

      _context.Admins.Add(admin);
      await _context.SaveChangesAsync();
      if (!result.Succeeded) return BadRequest(result.Errors);
      return Ok(user);
    }



  }
}
