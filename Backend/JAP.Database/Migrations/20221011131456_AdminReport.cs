using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAP.Database.Migrations
{
  public partial class AdminReport : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.UpdateData(
          table: "Comments",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 14, 56, 614, DateTimeKind.Local).AddTicks(769));

      migrationBuilder.UpdateData(
          table: "Comments",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 14, 56, 614, DateTimeKind.Local).AddTicks(771));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 14, 56, 614, DateTimeKind.Local).AddTicks(578));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 14, 56, 614, DateTimeKind.Local).AddTicks(613));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 3,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 14, 56, 614, DateTimeKind.Local).AddTicks(615));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 4,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 14, 56, 614, DateTimeKind.Local).AddTicks(616));

      migrationBuilder.UpdateData(
          table: "Selections",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 14, 56, 614, DateTimeKind.Local).AddTicks(718));

      migrationBuilder.UpdateData(
          table: "Selections",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 14, 56, 614, DateTimeKind.Local).AddTicks(723));
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.UpdateData(
          table: "Comments",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 12, 13, 228, DateTimeKind.Local).AddTicks(8481));

      migrationBuilder.UpdateData(
          table: "Comments",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 12, 13, 228, DateTimeKind.Local).AddTicks(8484));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 12, 13, 228, DateTimeKind.Local).AddTicks(8287));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 12, 13, 228, DateTimeKind.Local).AddTicks(8321));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 3,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 12, 13, 228, DateTimeKind.Local).AddTicks(8323));

      migrationBuilder.UpdateData(
          table: "Programs",
          keyColumn: "Id",
          keyValue: 4,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 12, 13, 228, DateTimeKind.Local).AddTicks(8325));

      migrationBuilder.UpdateData(
          table: "Selections",
          keyColumn: "Id",
          keyValue: 1,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 12, 13, 228, DateTimeKind.Local).AddTicks(8463));

      migrationBuilder.UpdateData(
          table: "Selections",
          keyColumn: "Id",
          keyValue: 2,
          column: "CreatedAt",
          value: new DateTime(2022, 10, 11, 15, 12, 13, 228, DateTimeKind.Local).AddTicks(8468));
    }
  }
}
