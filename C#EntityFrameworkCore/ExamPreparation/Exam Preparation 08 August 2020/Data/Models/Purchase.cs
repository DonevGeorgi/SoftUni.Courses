﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VaporStore.Data.Models.Enums;

namespace VaporStore.Data.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public PurchaseType Type { get; set; }
        [Required]
        public string ProductKey { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int CardId { get; set; }
        [Required]
        [ForeignKey(nameof(CardId))]
        public Card Card { get; set; }
        public int GameId { get; set; }
        [Required]
        [ForeignKey(nameof(GameId))]
        public Game Game { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Type – enumeration of type PurchaseType, with possible values ("Retail", "Digital") (required) 
//•	ProductKey – text, which consists of 3 pairs of 4 uppercase Latin letters and digits,
//separated by dashes (ex. "ABCD-EFGH-1J3L") (required) ^[A-Z0-9]{4}\-[A-Z0-9]{4}\-[A-Z0-9]{4}$
//•	Date – Date (required)
//•	CardId – integer, foreign key (required)
//•	Card – the purchase's card (required)
//•	GameId – integer, foreign key (required)
//•	Game – the purchase's game (required)
