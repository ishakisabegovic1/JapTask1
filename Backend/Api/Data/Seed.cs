using Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Api.Data
{
  public class Seed
  {
    public static async Task SeedData(AppDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager)
    {

      var roles = new List<Role>
      {
        new Role{Name = "Admin"},
        new Role{Name="Student"}
      };

      foreach (var role in roles)
      {
        await roleManager.CreateAsync(role);
      }

      var user = new User
      {
        Id = 1,
        UserName = "admin"
      };

      var admin = new Admin
      {
        Id = 1,
        UserId = 1
      };

      var rola = new UserRole
      {
        UserId = 1,
        RoleId = 1
      };

      await userManager.CreateAsync(user, "Password1");

      await userManager.AddToRoleAsync(user, "Admin");

      context.Admins.Add(admin);
      await context.SaveChangesAsync();

    }
  }
}
