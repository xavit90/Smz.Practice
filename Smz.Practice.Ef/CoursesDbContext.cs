using System;
using Microsoft.EntityFrameworkCore;
using Smz.Practice.Ef.Entities;

namespace Smz.Practice.Ef;

public class CoursesDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(local)\\SQLEXPRESS;Initial Catalog=DBCourses;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
