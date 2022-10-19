using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JAP.Database.Migrations
{
  public partial class spAdminReport : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      string procedure = @"Create procedure [dbo].[spAdminReportTab]
                                as
                                Begin
                                	SELECT s.Name as SelName,  p.Name as PrName, IsNull(numberOfStudents,0) as numberOfStudents,
                                                              IsNull(numberOfSuccess,0) as numberOfSuccess,
                                                              IsNull((numberOfSuccess*100/numberOfStudents),0) as SuccessRate
								  FROM [HAJDE.db].[dbo].Selections  s 

								  INNER JOIN [HAJDE.db].[dbo].Programs  p ON p.Id = s.ProgramId 
				
								  INNER JOIN (
								  SELECT SelectionId ,COUNT(*) as numberOfStudents FROM Students GROUP BY SelectionId
								  ) st on st.SelectionId = s.Id
 
								 LEFT JOIN (
								 SELECT  SelectionId, COUNT(*) as numberOfSuccess FROM Students WHERE students.Status = 'Success' GROUP BY SelectionId
								 ) stu on stu.SelectionId = s.Id
                                End";
      migrationBuilder.Sql(procedure);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      string procedure = @"Drop procedure [dbo].[spAdminReportTab]";
      migrationBuilder.Sql(procedure);
    }
  }
}
