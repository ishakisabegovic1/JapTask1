using Api.Entities;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Security.Cryptography.Xml;

namespace Api.Data
{
  public class AppDbContext : DbContext
  {

    public AppDbContext(DbContextOptions options) : base(options)
    {

    }


    public DbSet<User> Users { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Selection> Selections { get; set; }

    public DbSet<Entities.Program> Programs { get; set; }

    public DbSet<Comment> Comments { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {

      base.OnModelCreating(builder);

      //builder.Entity<JAP>()
      //    .HasMany(x => x.Selections);



      //builder.Entity<Selection>()
      //    .HasMany(x => x.Students);

      builder.Entity<Selection>()
          .HasOne(x => x.Jap)
          .WithMany(x => x.Selections)
          .HasForeignKey(x => x.JapId);

      builder.Entity<Student>()
          .HasOne(x => x.Selection)
          .WithMany(x => x.Students)
          .HasForeignKey(x => x.SelectionId);

      builder.Entity<Comment>()
           .HasKey(x => x.Id);

      builder.Entity<User>()
          .HasMany(x => x.Comments).WithOne(x => x.User);

      builder.Entity<Student>()
          .HasMany(x => x.Comments).WithOne(x => x.Student);

      builder.Entity<User>()
        .HasData(
          new User { Id = 1, UserName = "username", Password = "password" }
        );

      builder.Entity<Entities.Program>()
        .HasData(
        new Entities.Program { Id = 1, Name = "DEV" },
        new Entities.Program { Id = 2, Name = "QA" },
        new Entities.Program { Id = 3, Name = "DevOps" },
        new Entities.Program { Id = 4, Name = "TA" }
        );

      builder.Entity<Entities.Selection>()
        .HasData(
          new Selection { Id = 1, Name = "DEV 09/21", StartDate = new DateTime(2022, 9, 1), EndDate = new DateTime(2022, 10, 1), JapId = 1, Status = "Active" },
          new Selection { Id = 2, Name = "QA 09/21", StartDate = new DateTime(2022, 8, 10), EndDate = new DateTime(2022, 10, 15), JapId = 2, Status = "Active" }
        );

      builder.Entity<Entities.Student>()
        .HasData(
          new Student { Id = 1, Name = "Student studentic", DateOfBirth = new DateTime(1998, 9, 1), SelectionId = 1, Status = "InProgress", Address = "adresica" },
          new Student { Id = 2, Name = "Student studentic 1", DateOfBirth = new DateTime(1998, 12, 1), SelectionId = 2, Status = "Extended", Address = "adresica 2" }
        );

      builder.Entity<Comment>()
        .HasData(
        new Comment { Id = 1, StudentId = 1, UserId = 1, comment = "komentar" },
        new Comment { Id = 2, StudentId = 2, UserId = 1, comment = "komentar1" }
        );








    }
  }
}
