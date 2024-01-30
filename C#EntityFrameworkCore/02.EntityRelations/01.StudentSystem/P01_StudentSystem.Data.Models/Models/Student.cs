using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student() 
        {
            StudentsCourses = new List<StudentCourse>();
            Homeworks = new List<Homework>();
        }

        [Key]
        public int StudentId { get; set; }
        [Required]
        [MaxLength(100)]
        [Unicode(true)]
        public string Name { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }

        public ICollection<StudentCourse> StudentsCourses { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
}
