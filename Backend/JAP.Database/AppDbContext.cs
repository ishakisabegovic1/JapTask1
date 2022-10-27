
using JAP.Core;
using JAP.Core.Entities;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;
using System.Security.Cryptography.Xml;

namespace JAP.Database
{
  public class AppDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole,
    IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
  {

    public AppDbContext(DbContextOptions options) : base(options)
    {

    }


    public DbSet<User> Users { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Selection> Selections { get; set; }
    public DbSet<JAP.Core.Program> Programs { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<AdminReportDto> AdminReports { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ProgramItem> ProgramItems { get; set; }
    public DbSet<ProgramItemStudent> ProgramItemStudents { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {

      base.OnModelCreating(builder);

      builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

      SeedData(builder);

    }

    private static void SeedData(ModelBuilder builder)
    {
      builder.Entity<Program>()
        .HasData(
        new Program { Id = 1, Name = "DEV" },
        new Program { Id = 2, Name = "QA" },
        new Program { Id = 3, Name = "DevOps" },
        new Program { Id = 4, Name = "TA" }
        );

      builder.Entity<Selection>()
        .HasData(
          new Selection { Id = 1, Name = "DEV 09/21", StartDate = new DateTime(2022, 9, 1), EndDate = new DateTime(2022, 10, 1), ProgramId = 1, Status = "Active" },
          new Selection { Id = 2, Name = "QA 09/21", StartDate = new DateTime(2022, 8, 10), EndDate = new DateTime(2022, 10, 15), ProgramId = 2, Status = "Active" }
        );

      //builder.Entity<Student>()
      //  .HasData(
      //    new Student { Id = 1, Name = "Student studentic", DateOfBirth = new DateTime(1998, 9, 1), SelectionId = 1, Status = "InProgress", Address = "adresica" },
      //    new Student { Id = 2, Name = "Student studentic 1", DateOfBirth = new DateTime(1998, 12, 1), SelectionId = 2, Status = "Extended", Address = "adresica 2" }
      //  );

      builder.Entity<Comment>()
        .HasData(
        new Comment { Id = 1, StudentId = 1, AdminId = 1, comment = "komentar" },
        new Comment { Id = 2, StudentId = 2, AdminId = 1, comment = "komentar1" }
        );
    }
  }
}
