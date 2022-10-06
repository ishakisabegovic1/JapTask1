using Api.Data;
using Api.Helpers;
using Api.Repositories.Comment;
using Api.Repositories.Program;
using Api.Repositories.Selection;
using Api.Repositories.Student;
using Api.Services.Comment;
using Api.Services.Program;
using Api.Services.Selection;
using Api.Services.Student;
using Api.Services.Token;
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

      services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
      services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
          config.GetConnectionString("DefaultConnection")));
      return services;
    }

  }
}
