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

        public DbSet<Entities.Program> Japs  { get; set; }

        public DbSet<Comment> UserStudents { get; set; }



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
                .HasForeignKey(x=>x.JapId);

            builder.Entity<Student>()
                .HasOne(x => x.Selection)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.SelectionId);

            builder.Entity<Comment>()
                 .HasKey(x => x.Id);

            builder.Entity<User>()
                .HasMany(x => x.Comments).WithOne(x=>x.User);

            builder.Entity<Student>()
                .HasMany(x => x.Comments).WithOne(x=>x.Student);
                
                








        }
    }
}
