using Api.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Api.Data
{
    public class Seed
    {
        public static async Task SeedData(AppDbContext context)
        {

            if (await context.Japs.AnyAsync()) return;
            var japData = await System.IO.File.ReadAllTextAsync("Data/DataDump/japs.json");
            var japs = JsonSerializer.Deserialize<List<Entities.Program>>(japData);
            foreach (var jap in japs)
            {
                context.Japs.Add(jap);
            }

            if (await context.Selections.AnyAsync()) return;
            var selectionData = await System.IO.File.ReadAllTextAsync("Data/DataDump/selections.json");
            var selections = JsonSerializer.Deserialize<List<Selection>>(selectionData);
            foreach (var sel in selections)
            {
                context.Selections.Add(sel);
            }

            if (await context.Students.AnyAsync()) return;
            var studentData = await System.IO.File.ReadAllTextAsync("Data/DataDump/students.json");
            var students = JsonSerializer.Deserialize<List<Student>>(studentData);
            foreach (var stud in students)
            {
                context.Students.Add(stud);
            }

            if (await context.UserStudents.AnyAsync()) return;
            var userStudentData = await System.IO.File.ReadAllTextAsync("Data/DataDump/comments.json");
            var userStudents = JsonSerializer.Deserialize<List<Comment>>(userStudentData);
            foreach (var comm in userStudents)
            {
                context.UserStudents.Add(comm);
            }


            await context.SaveChangesAsync();


        }
    }
}
