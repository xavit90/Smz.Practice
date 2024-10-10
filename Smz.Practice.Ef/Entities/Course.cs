using System.ComponentModel.DataAnnotations;

namespace Smz.Practice.Ef.Entities;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int AuthorId { get; set; }
    public Author Author { get; set; } = new();
}
