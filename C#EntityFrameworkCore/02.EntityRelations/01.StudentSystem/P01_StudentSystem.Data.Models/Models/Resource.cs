using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }
        [Required]
        [MaxLength(50)]
        [Unicode(true)]
        public string Name { get; set; }
        [Required]
        [Unicode(false)]
        public string Url { get; set; }
        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }
    }
}
