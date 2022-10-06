using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class completeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Curriculum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Selections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JapId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Selections_Programs_JapId",
                        column: x => x.JapId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Selections_SelectionId",
                        column: x => x.SelectionId,
                        principalTable: "Selections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Programs",
                columns: new[] { "Id", "CreatedAt", "Curriculum", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 10, 6, 13, 57, 38, 974, DateTimeKind.Local).AddTicks(1149), null, "DEV" },
                    { 2, new DateTime(2022, 10, 6, 13, 57, 38, 974, DateTimeKind.Local).AddTicks(1152), null, "QA" },
                    { 3, new DateTime(2022, 10, 6, 13, 57, 38, 974, DateTimeKind.Local).AddTicks(1154), null, "DevOps" },
                    { 4, new DateTime(2022, 10, 6, 13, 57, 38, 974, DateTimeKind.Local).AddTicks(1155), null, "TA" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Password", "UserName" },
                values: new object[] { 1, new DateTime(2022, 10, 6, 13, 57, 38, 974, DateTimeKind.Local).AddTicks(1020), "password", "username" });

            migrationBuilder.InsertData(
                table: "Selections",
                columns: new[] { "Id", "CreatedAt", "EndDate", "JapId", "Name", "StartDate", "Status" },
                values: new object[] { 1, new DateTime(2022, 10, 6, 13, 57, 38, 974, DateTimeKind.Local).AddTicks(1167), new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "DEV 09/21", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" });

            migrationBuilder.InsertData(
                table: "Selections",
                columns: new[] { "Id", "CreatedAt", "EndDate", "JapId", "Name", "StartDate", "Status" },
                values: new object[] { 2, new DateTime(2022, 10, 6, 13, 57, 38, 974, DateTimeKind.Local).AddTicks(1172), new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "QA 09/21", new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Active" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CreatedAt", "DateOfBirth", "Name", "SelectionId", "Status" },
                values: new object[] { 1, "adresica", new DateTime(2022, 10, 6, 13, 57, 38, 974, DateTimeKind.Local).AddTicks(1182), new DateTime(1998, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student studentic", 1, "InProgress" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "CreatedAt", "DateOfBirth", "Name", "SelectionId", "Status" },
                values: new object[] { 2, "adresica 2", new DateTime(2022, 10, 6, 13, 57, 38, 974, DateTimeKind.Local).AddTicks(1187), new DateTime(1998, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student studentic 1", 2, "Extended" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "StudentId", "UserId", "comment" },
                values: new object[] { 1, new DateTime(2022, 10, 6, 13, 57, 38, 974, DateTimeKind.Local).AddTicks(1199), 1, 1, "komentar" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "StudentId", "UserId", "comment" },
                values: new object[] { 2, new DateTime(2022, 10, 6, 13, 57, 38, 974, DateTimeKind.Local).AddTicks(1201), 2, 1, "komentar1" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_StudentId",
                table: "Comments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Selections_JapId",
                table: "Selections",
                column: "JapId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SelectionId",
                table: "Students",
                column: "SelectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Selections");

            migrationBuilder.DropTable(
                name: "Programs");
        }
    }
}
