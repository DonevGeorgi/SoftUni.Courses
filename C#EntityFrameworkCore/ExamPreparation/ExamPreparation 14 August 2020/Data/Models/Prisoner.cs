﻿using Castle.DynamicProxy.Generators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Prisoner
    {
        public Prisoner() 
        {
            Mails = new List<Mail>();
            PrisonerOfficers = new List<OfficerPrisoner>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string FullName { get; set; }
        [Required]
        public string Nickname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime IncarcerationDate { get; set; }
        public DateTime? ReleaseDate { get; set; } = null!;
        public decimal? Bail { get; set; }
        public int CellId { get; set; }
        [ForeignKey(nameof(CellId))]
        public Cell Cell { get; set; }
        public virtual ICollection<Mail> Mails { get; set; }
        public virtual ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	FullName – text with min length 3 and max length 20 (required)
//•	Nickname – text starting with "The " and a single word only of letters with an uppercase letter for beginning(example: The Prisoner) (required)
//•	Age – integer in the range [18, 65] (required)
//•	IncarcerationDate ¬– Date (required)
//•	ReleaseDate – Date
//•	Bail – decimal (non-negative, minimum value: 0)
//•	CellId - integer, foreign key
//•	Cell – the prisoner's cell
//•	Mails – collection of type Mail
//•	PrisonerOfficers - collection of type OfficerPrisoner
