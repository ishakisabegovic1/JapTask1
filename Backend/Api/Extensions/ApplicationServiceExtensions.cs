
using JAP.Core;
using JAP.Core.Interfaces;
using JAP.Core.MapperProfiles;
using JAP.Database;
using JAP.Repositories;
using JAP.Services;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
  public static class ApplicationServiceExtensions
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
      services.AddScoped<ITokenService, TokenService>();

      services.AddScoped<IProgramRepository, ProgramRepository>();
      services.AddScoped<IProgramService, ProgramService>();

      services.AddScoped<ISelectionRepository, SelectionRepository>();
      services.AddScoped<ISelectionService, SelectionService>();

      services.AddScoped<IStudentRepository, StudentRepository>();
      services.AddScoped<IStudentService, StudentService>();

      services.AddScoped<ICommentRepository, CommentRepository>();
      services.AddScoped<ICommentService, CommentService>();

      services.AddScoped<IAuthService, AuthService>();

      services.AddScoped<IEmailService, EmailService>();

      services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

      services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
          config.GetConnectionString("DefaultConnection")));


      return services;
    }

  }
}
