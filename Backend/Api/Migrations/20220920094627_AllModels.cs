using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    public partial class AllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Students_StudentId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Selections_SelectionId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProgramStatus",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Selection",
                table: "Students",
                newName: "StudentStatus");

            migrationBuilder.AlterColumn<int>(
                name: "SelectionId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JapId",
                table: "Selections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Japs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Curriculum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Japs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Selections_JapId",
                table: "Selections",
                column: "JapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Students_StudentId",
                table: "Comment",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Selections_Japs_JapId",
                table: "Selections",
                column: "JapId",
                principalTable: "Japs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Selections_SelectionId",
                table: "Students",
                column: "SelectionId",
                principalTable: "Selections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Students_StudentId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Selections_Japs_JapId",
                table: "Selections");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Selections_SelectionId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Japs");

            migrationBuilder.DropIndex(
                name: "IX_Selections_JapId",
                table: "Selections");

            migrationBuilder.DropColumn(
                name: "JapId",
                table: "Selections");

            migrationBuilder.RenameColumn(
                name: "StudentStatus",
                table: "Students",
                newName: "Selection");

            migrationBuilder.AlterColumn<int>(
                name: "SelectionId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ProgramStatus",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Comment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Students_StudentId",
                table: "Comment",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Selections_SelectionId",
                table: "Students",
                column: "SelectionId",
                principalTable: "Selections",
                principalColumn: "Id");
        }
    }
}
