using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAP.Database.Migrations
{
  public partial class addedAdmin : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Admin_AspNetUsers_UserId",
          table: "Admin");

      migrationBuilder.DropForeignKey(
          name: "FK_Comments_Admin_AdminId",
          table: "Comments");

      migrationBuilder.DropPrimaryKey(
          name: "PK_Admin",
          table: "Admin");

      migrationBuilder.RenameTable(
          name: "Admin",
          newName: "Admins");

      migrationBuilder.RenameIndex(
          name: "IX_Admin_UserId",
          table: "Admins",
          newName: "IX_Admins_UserId");

      migrationBuilder.AddPrimaryKey(
          name: "PK_Admins",
          table: "Admins",
          column: "Id");

      migrationBuilder.UpdateData(
          table: "Comments",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 14, 55, 46, 91, DateTimeKind.Local).AddTicks(831));

      migrationBuilder.UpdateData(
          table: "Comments",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 14, 55, 46, 91, DateTimeKind.Local).AddTicks(833));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 14, 55, 46, 91, DateTimeKind.Local).AddTicks(585));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 14, 55, 46, 91, DateTimeKind.Local).AddTicks(618));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 3,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 14, 55, 46, 91, DateTimeKind.Local).AddTicks(620));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 4,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 14, 55, 46, 91, DateTimeKind.Local).AddTicks(622));

      migrationBuilder.UpdateData(
          table: "Selections",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 14, 55, 46, 91, DateTimeKind.Local).AddTicks(812));

      migrationBuilder.UpdateData(
          table: "Selections",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 14, 55, 46, 91, DateTimeKind.Local).AddTicks(818));

      migrationBuilder.AddForeignKey(
          name: "FK_Admins_AspNetUsers_UserId",
          table: "Admins",
          column: "UserId",
          principalTable: "AspNetUsers",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
          name: "FK_Comments_Admins_AdminId",
          table: "Comments",
          column: "AdminId",
          principalTable: "Admins",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Admins_AspNetUsers_UserId",
          table: "Admins");

      migrationBuilder.DropForeignKey(
          name: "FK_Comments_Admins_AdminId",
          table: "Comments");

      migrationBuilder.DropPrimaryKey(
          name: "PK_Admins",
          table: "Admins");

      migrationBuilder.RenameTable(
          name: "Admins",
          newName: "Admin");

      migrationBuilder.RenameIndex(
          name: "IX_Admins_UserId",
          table: "Admin",
          newName: "IX_Admin_UserId");

      migrationBuilder.AddPrimaryKey(
          name: "PK_Admin",
          table: "Admin",
          column: "Id");

      migrationBuilder.UpdateData(
          table: "Comments",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3826));

      migrationBuilder.UpdateData(
          table: "Comments",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3830));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3558));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3596));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 3,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3599));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 4,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3601));

      migrationBuilder.UpdateData(
          table: "Selections",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3800));

      migrationBuilder.UpdateData(
          table: "Selections",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 8, 13, 58, 52, 874, DateTimeKind.Local).AddTicks(3808));

      migrationBuilder.AddForeignKey(
          name: "FK_Admin_AspNetUsers_UserId",
          table: "Admin",
          column: "UserId",
          principalTable: "AspNetUsers",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
          name: "FK_Comments_Admin_AdminId",
          table: "Comments",
          column: "AdminId",
          principalTable: "Admin",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);
    }
  }
}
