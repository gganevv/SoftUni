namespace P01_StudentSystem.Data.Models;

using P01_StudentSystem.Data.Common;
using System.ComponentModel.DataAnnotations;

public class Student
{
    public Student()
    {
        StudentsCourses = new HashSet<StudentCourse>();
        Homeworks = new HashSet<Homework>();
    }

    [Key]
    public int StudentId { get; set; }

    [Required]
    [StringLength(ValidationConstrants.StudentNameMaxLength)]
    public string Name { get; set; } = null!;

    [MaxLength(ValidationConstrants.StudentNumberMaxMinLength)]
    [MinLength(ValidationConstrants.StudentNumberMaxMinLength)]
    public string? PhoneNumber { get; set; }

    [Required]
    public DateTime RegisteredOn { get; set; }

    public DateTime? Birthday { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }

    public virtual ICollection<Homework> Homeworks { get; set; }
}