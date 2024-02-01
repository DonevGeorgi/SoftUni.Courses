using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        public Performer()
        {
            PerformerSongs = new List<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public decimal NetWorth { get; set; }
        public ICollection<SongPerformer> PerformerSongs  { get; set; }

    }
}