using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAP.Database.Migrations
{
  public partial class overallSuccess : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      string procedure = @"Create procedure [dbo].[spOverallSuccess]
                                as
                                Begin
                                SELECT  IsNull((COUNT(*)),0) as OverallSuccess 
								 FROM Students 
								 WHERE students.Status = 'Success' 	
                                End";
      migrationBuilder.Sql(procedure);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      string procedure = @"Drop procedure [dbo].[spOverallSuccess]";
      migrationBuilder.Sql(procedure);
    }
  }
}
