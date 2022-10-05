using Api.Data;
using Api.Helpers;
using Api.Services.Token;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions
{
    public static class ApplicationServiceExtensions
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
      services.AddScoped<ITokenService, TokenService>();
      services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
      services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
          config.GetConnectionString("DefaultConnection")));
      return services;
    }

  }
}
