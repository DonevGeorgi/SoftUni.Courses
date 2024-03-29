﻿using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class Genre
    {
        public Genre() 
        {
            Games = new List<Game>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Name – text (required)
//•	Games - collection of type Game

