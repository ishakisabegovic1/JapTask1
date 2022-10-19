// <auto-generated />


using JAP.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JAP.Database.Migrations
{
  [DbContext(typeof(AppDbContext))]
  [Migration("20221008115853_completeMig")]
  partial class completeMig
  {
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("ProductVersion", "6.0.9")
          .HasAnnotation("Relational:MaxIdentifierLength", 128);

      SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

      modelBuilder.Entity("Api.Entities.Admin", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<DateTime>("CreatedAt")
                      .HasColumnType("datetime2");

            b.Property<int>("UserId")
                      .HasColumnType("int");

            b.HasKey("Id");

            b.HasIndex("UserId")
                      .IsUnique();

            b.ToTable("Admin");
          });

      modelBuilder.Entity("Api.Entities.Comment", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<int>("AdminId")
                      .HasColumnType("int");

            b.Property<DateTime>("CreatedAt")
                      .HasColumnType("datetime2");

            b.Property<int>("StudentId")
                      .HasColumnType("int");

            b.Property<string>("comment")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.HasKey("Id");

            b.HasIndex("AdminId");

            b.HasIndex("StudentId");

            b.ToTable("Comments");

            b.HasData(
                      new
                  {
                    Id = 1,
                    AdminId = 1,
                    CreatedAt = new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3826),
                    StudentId = 1,
                    comment = "komentar"
                  },
                      new
                  {
                    Id = 2,
                    AdminId = 1,
                    CreatedAt = new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3830),
                    StudentId = 2,
                    comment = "komentar1"
                  });
          });

      modelBuilder.Entity("Api.Entities.Program", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<DateTime>("CreatedAt")
                      .HasColumnType("datetime2");

            b.Property<string>("Curriculum")
                      .HasColumnType("nvarchar(max)");

            b.Property<string>("Name")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.HasKey("Id");

            b.ToTable("Programs");

            b.HasData(
                      new
                  {
                    Id = 1,
                    CreatedAt = new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3558),
                    Name = "DEV"
                  },
                      new
                  {
                    Id = 2,
                    CreatedAt = new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3596),
                    Name = "QA"
                  },
                      new
                  {
                    Id = 3,
                    CreatedAt = new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3599),
                    Name = "DevOps"
                  },
                      new
                  {
                    Id = 4,
                    CreatedAt = new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3601),
                    Name = "TA"
                  });
          });

      modelBuilder.Entity("Api.Entities.Role", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<string>("ConcurrencyStamp")
                      .IsConcurrencyToken()
                      .HasColumnType("nvarchar(max)");

            b.Property<string>("Name")
                      .HasMaxLength(256)
                      .HasColumnType("nvarchar(256)");

            b.Property<string>("NormalizedName")
                      .HasMaxLength(256)
                      .HasColumnType("nvarchar(256)");

            b.HasKey("Id");

            b.HasIndex("NormalizedName")
                      .IsUnique()
                      .HasDatabaseName("RoleNameIndex")
                      .HasFilter("[NormalizedName] IS NOT NULL");

            b.ToTable("AspNetRoles", (string)null);
          });

      modelBuilder.Entity("Api.Entities.Selection", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<DateTime>("CreatedAt")
                      .HasColumnType("datetime2");

            b.Property<DateTime>("EndDate")
                      .HasColumnType("datetime2");

            b.Property<int>("ProgramId")
                      .HasColumnType("int");

            b.Property<string>("Name")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.Property<DateTime>("StartDate")
                      .HasColumnType("datetime2");

            b.Property<string>("Status")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.HasKey("Id");

            b.HasIndex("ProgramId");

            b.ToTable("Selections");

            b.HasData(
                      new
                  {
                    Id = 1,
                    CreatedAt = new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3800),
                    EndDate = new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    JapId = 1,
                    Name = "DEV 09/21",
                    StartDate = new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    Status = "Active"
                  },
                      new
                  {
                    Id = 2,
                    CreatedAt = new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3808),
                    EndDate = new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    JapId = 2,
                    Name = "QA 09/21",
                    StartDate = new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    Status = "Active"
                  });
          });

      modelBuilder.Entity("Api.Entities.Student", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<string>("Address")
                      .HasColumnType("nvarchar(max)");

            b.Property<DateTime>("CreatedAt")
                      .HasColumnType("datetime2");

            b.Property<DateTime?>("DateOfBirth")
                      .HasColumnType("datetime2");

            b.Property<string>("Name")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.Property<int>("SelectionId")
                      .HasColumnType("int");

            b.Property<string>("Status")
                      .IsRequired()
                      .HasColumnType("nvarchar(max)");

            b.Property<int>("UserId")
                      .HasColumnType("int");

            b.HasKey("Id");

            b.HasIndex("SelectionId");

            b.HasIndex("UserId")
                      .IsUnique();

            b.ToTable("Students");
          });

      modelBuilder.Entity("Api.Entities.User", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<int>("AccessFailedCount")
                      .HasColumnType("int");

            b.Property<string>("ConcurrencyStamp")
                      .IsConcurrencyToken()
                      .HasColumnType("nvarchar(max)");

            b.Property<string>("Email")
                      .HasMaxLength(256)
                      .HasColumnType("nvarchar(256)");

            b.Property<bool>("EmailConfirmed")
                      .HasColumnType("bit");

            b.Property<bool>("LockoutEnabled")
                      .HasColumnType("bit");

            b.Property<DateTimeOffset?>("LockoutEnd")
                      .HasColumnType("datetimeoffset");

            b.Property<string>("NormalizedEmail")
                      .HasMaxLength(256)
                      .HasColumnType("nvarchar(256)");

            b.Property<string>("NormalizedUserName")
                      .HasMaxLength(256)
                      .HasColumnType("nvarchar(256)");

            b.Property<string>("PasswordHash")
                      .HasColumnType("nvarchar(max)");

            b.Property<string>("PhoneNumber")
                      .HasColumnType("nvarchar(max)");

            b.Property<bool>("PhoneNumberConfirmed")
                      .HasColumnType("bit");

            b.Property<string>("SecurityStamp")
                      .HasColumnType("nvarchar(max)");

            b.Property<bool>("TwoFactorEnabled")
                      .HasColumnType("bit");

            b.Property<string>("UserName")
                      .HasMaxLength(256)
                      .HasColumnType("nvarchar(256)");

            b.HasKey("Id");

            b.HasIndex("NormalizedEmail")
                      .HasDatabaseName("EmailIndex");

            b.HasIndex("NormalizedUserName")
                      .IsUnique()
                      .HasDatabaseName("UserNameIndex")
                      .HasFilter("[NormalizedUserName] IS NOT NULL");

            b.ToTable("AspNetUsers", (string)null);
          });

      modelBuilder.Entity("Api.Entities.UserRole", b =>
          {
            b.Property<int>("UserId")
                      .HasColumnType("int");

            b.Property<int>("RoleId")
                      .HasColumnType("int");

            b.HasKey("UserId", "RoleId");

            b.HasIndex("RoleId");

            b.ToTable("AspNetUserRoles", (string)null);
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<string>("ClaimType")
                      .HasColumnType("nvarchar(max)");

            b.Property<string>("ClaimValue")
                      .HasColumnType("nvarchar(max)");

            b.Property<int>("RoleId")
                      .HasColumnType("int");

            b.HasKey("Id");

            b.HasIndex("RoleId");

            b.ToTable("AspNetRoleClaims", (string)null);
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<string>("ClaimType")
                      .HasColumnType("nvarchar(max)");

            b.Property<string>("ClaimValue")
                      .HasColumnType("nvarchar(max)");

            b.Property<int>("UserId")
                      .HasColumnType("int");

            b.HasKey("Id");

            b.HasIndex("UserId");

            b.ToTable("AspNetUserClaims", (string)null);
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
          {
            b.Property<string>("LoginProvider")
                      .HasColumnType("nvarchar(450)");

            b.Property<string>("ProviderKey")
                      .HasColumnType("nvarchar(450)");

            b.Property<string>("ProviderDisplayName")
                      .HasColumnType("nvarchar(max)");

            b.Property<int>("UserId")
                      .HasColumnType("int");

            b.HasKey("LoginProvider", "ProviderKey");

            b.HasIndex("UserId");

            b.ToTable("AspNetUserLogins", (string)null);
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
          {
            b.Property<int>("UserId")
                      .HasColumnType("int");

            b.Property<string>("LoginProvider")
                      .HasColumnType("nvarchar(450)");

            b.Property<string>("Name")
                      .HasColumnType("nvarchar(450)");

            b.Property<string>("Value")
                      .HasColumnType("nvarchar(max)");

            b.HasKey("UserId", "LoginProvider", "Name");

            b.ToTable("AspNetUserTokens", (string)null);
          });

      modelBuilder.Entity("Api.Entities.Admin", b =>
          {
            b.HasOne("Api.Entities.User", "User")
                      .WithOne("Admin")
                      .HasForeignKey("Api.Entities.Admin", "UserId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("User");
          });

      modelBuilder.Entity("Api.Entities.Comment", b =>
          {
            b.HasOne("Api.Entities.Admin", "Admin")
                      .WithMany("Comments")
                      .HasForeignKey("AdminId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.HasOne("Api.Entities.Student", "Student")
                      .WithMany("Comments")
                      .HasForeignKey("StudentId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Admin");

            b.Navigation("Student");
          });

      modelBuilder.Entity("Api.Entities.Selection", b =>
          {
            b.HasOne("Api.Entities.Program", "Program")
                      .WithMany("Selections")
                      .HasForeignKey("ProgramId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Program");
          });

      modelBuilder.Entity("Api.Entities.Student", b =>
          {
            b.HasOne("Api.Entities.Selection", "Selection")
                      .WithMany("Students")
                      .HasForeignKey("SelectionId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.HasOne("Api.Entities.User", "User")
                      .WithOne("Student")
                      .HasForeignKey("Api.Entities.Student", "UserId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Selection");

            b.Navigation("User");
          });

      modelBuilder.Entity("Api.Entities.UserRole", b =>
          {
            b.HasOne("Api.Entities.Role", "Role")
                      .WithMany("UserRoles")
                      .HasForeignKey("RoleId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.HasOne("Api.Entities.User", "User")
                      .WithMany("UserRoles")
                      .HasForeignKey("UserId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

            b.Navigation("Role");

            b.Navigation("User");
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
          {
            b.HasOne("Api.Entities.Role", null)
                      .WithMany()
                      .HasForeignKey("RoleId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
          {
            b.HasOne("Api.Entities.User", null)
                      .WithMany()
                      .HasForeignKey("UserId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
          {
            b.HasOne("Api.Entities.User", null)
                      .WithMany()
                      .HasForeignKey("UserId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
          });

      modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
          {
            b.HasOne("Api.Entities.User", null)
                      .WithMany()
                      .HasForeignKey("UserId")
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();
          });

      modelBuilder.Entity("Api.Entities.Admin", b =>
          {
            b.Navigation("Comments");
          });

      modelBuilder.Entity("Api.Entities.Program", b =>
          {
            b.Navigation("Selections");
          });

      modelBuilder.Entity("Api.Entities.Role", b =>
          {
            b.Navigation("UserRoles");
          });

      modelBuilder.Entity("Api.Entities.Selection", b =>
          {
            b.Navigation("Students");
          });

      modelBuilder.Entity("Api.Entities.Student", b =>
          {
            b.Navigation("Comments");
          });

      modelBuilder.Entity("Api.Entities.User", b =>
          {
            b.Navigation("Admin");

            b.Navigation("Student");

            b.Navigation("UserRoles");
          });
#pragma warning restore 612, 618
    }
  }
}
