using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class Tag
    {
        public Tag() 
        {
            GameTags = new List<GameTag>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<GameTag> GameTags { get; set;}
    }
}

//•	Id – integer, Primary Key
//•	Name – text (required)
//•	GameTags – collection of type GameTag

