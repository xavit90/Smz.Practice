using Smz.Practice.Ef;
using Smz.Practice.Ef.Entities;

var context = new CoursesDbContext();
context.Database.EnsureCreated();

context.Authors.Add(new Author {
    Name = "Fabian Lopez",
    Courses = new List<Course>([
        new Course { Name = "NET 5" },
        new Course { Name = "NET 6" },
        new Course { Name = "NET 7" },
        new Course { Name = "NET 8" }
    ])
});
context.SaveChanges();
Console.WriteLine("¡Proceso Concluido!");