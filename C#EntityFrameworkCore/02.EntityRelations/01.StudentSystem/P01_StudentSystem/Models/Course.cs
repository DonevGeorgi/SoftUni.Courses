using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course() 
        {
            Resources = new List<Resource>();
            Homeworks = new List<Homeworks>();
            StudentsCourses = new List<StudentCourse>();
        }

        [Key]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(80)]
        [Unicode(true)]
        public string Name { get; set; }
        [Unicode(true)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int Price { get; set; }

        public ICollection<Resource> Resources { get; set; }
        public ICollection<Homeworks> Homeworks { get; set; }
        public ICollection<StudentCourse> StudentsCourses { get; set; }
    }
}