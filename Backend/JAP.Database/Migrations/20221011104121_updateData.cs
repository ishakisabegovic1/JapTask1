using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAP.Database.Migrations
{
  public partial class updateData : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.UpdateData(
          table: "Comments",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 12, 41, 21, 52, DateTimeKind.Local).AddTicks(4019));

      migrationBuilder.UpdateData(
          table: "Comments",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 12, 41, 21, 52, DateTimeKind.Local).AddTicks(4022));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 12, 41, 21, 52, DateTimeKind.Local).AddTicks(3768));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 12, 41, 21, 52, DateTimeKind.Local).AddTicks(3801));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 3,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 12, 41, 21, 52, DateTimeKind.Local).AddTicks(3803));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 4,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 12, 41, 21, 52, DateTimeKind.Local).AddTicks(3804));

      migrationBuilder.UpdateData(
          table: "Selections",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 12, 41, 21, 52, DateTimeKind.Local).AddTicks(4004));

      migrationBuilder.UpdateData(
          table: "Selections",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 12, 41, 21, 52, DateTimeKind.Local).AddTicks(4009));
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
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
    }
  }
}
