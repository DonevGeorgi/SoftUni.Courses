using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models
{
    public class Game
    {
        public Game() 
        {
            Purchases = new List<Purchase>();
            GameTags = new List<GameTag>();
        }   

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int DeveloperId { get; set; }
        [Required]
        [ForeignKey(nameof(DeveloperId))]
        public Developer Developer { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set;}
        public virtual ICollection<GameTag> GameTags { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Name – text (required)
//•	Price – decimal (non-negative, minimum value: 0) (required)
//•	ReleaseDate – Date (required)
//•	DeveloperId – integer, foreign key (required)
//•	Developer – the game's developer (required)
//•	GenreId – integer, foreign key (required)
//•	Genre – the game's genre (required)
//•	Purchases - collection of type Purchase
//•	GameTags - collection of type GameTag. Each game must have at least one tag.
