using System.ComponentModel.DataAnnotations;

namespace Homies.Data.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstants.TypeNameMaxLength)]
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Event> Event { get; set; } = new List<Event>();
    }
}
