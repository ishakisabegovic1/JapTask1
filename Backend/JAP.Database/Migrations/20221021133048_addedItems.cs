using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAP.Database.Migrations
{
  public partial class addedItems : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Items",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
            ExpectedNumberOfHours = table.Column<int>(type: "int", nullable: false),
            IsLecture = table.Column<bool>(type: "bit", nullable: false),
            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Items", x => x.Id);
          });

      migrationBuilder.CreateTable(
          name: "ProgramItems",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            ProgramId = table.Column<int>(type: "int", nullable: false),
            ItemId = table.Column<int>(type: "int", nullable: false),
            OrderNumber = table.Column<int>(type: "int", nullable: false),
            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ProgramItems", x => x.Id);
            table.ForeignKey(
                      name: "FK_ProgramItems_Items_ItemId",
                      column: x => x.ItemId,
                      principalTable: "Items",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_ProgramItems_Programs_ProgramId",
                      column: x => x.ProgramId,
                      principalTable: "Programs",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateTable(
          name: "ProgramItemStudents",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            ProgramItemId = table.Column<int>(type: "int", nullable: false),
            StudentId = table.Column<int>(type: "int", nullable: false),
            StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            DoneByCandidate = table.Column<int>(type: "int", nullable: true),
            StatusByCandidate = table.Column<string>(type: "nvarchar(max)", nullable: true),
            CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_ProgramItemStudents", x => x.Id);
            table.ForeignKey(
                      name: "FK_ProgramItemStudents_ProgramItems_ProgramItemId",
                      column: x => x.ProgramItemId,
                      principalTable: "ProgramItems",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_ProgramItemStudents_Students_StudentId",
                      column: x => x.StudentId,
                      principalTable: "Students",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });



      migrationBuilder.CreateIndex(
          name: "IX_ProgramItems_ItemId",
          table: "ProgramItems",
          column: "ItemId");

      migrationBuilder.CreateIndex(
          name: "IX_ProgramItems_ProgramId",
          table: "ProgramItems",
          column: "ProgramId");

      migrationBuilder.CreateIndex(
          name: "IX_ProgramItemStudents_ProgramItemId",
          table: "ProgramItemStudents",
          column: "ProgramItemId");

      migrationBuilder.CreateIndex(
          name: "IX_ProgramItemStudents_StudentId",
          table: "ProgramItemStudents",
          column: "StudentId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "ProgramItemStudents");

      migrationBuilder.DropTable(
          name: "ProgramItems");

      migrationBuilder.DropTable(
          name: "Items");


    }
  }
}
