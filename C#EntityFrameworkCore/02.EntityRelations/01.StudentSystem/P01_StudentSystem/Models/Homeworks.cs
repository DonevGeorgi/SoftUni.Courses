﻿using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Homeworks
    {
        [Key]
        public int HomeworkId { get; set; }
        [Required]
        [Unicode(false)]
        public string Content { get; set; }
        [Required]
        public ContentType ContentType { get; set; }
        [Required]
        public DateTime SubmissionTime { get; set; }
        [Required]
        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student Student { get; set; }
        [Required]
        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }
    }
}
