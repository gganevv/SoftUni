using P01_StudentSystem.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models;

public class Course
{
    public Course()
    {
        StudentsCourses = new HashSet<StudentCourse>();
        Resources = new HashSet<Resource>();
        Homeworks = new HashSet<Homework>();
    }

    [Key]
    public int CourseId { get; set; }

    [Required]
    [MaxLength(ValidationConstrants.CourseNameMaxLength)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public decimal Price { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }

    public virtual ICollection<Resource> Resources { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }

}