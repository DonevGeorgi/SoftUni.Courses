using SoftJail.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class OfficerPrisoner
    {
        public int OfficerId { get; set; }
        [Required]
        [ForeignKey(nameof(OfficerId))]
        public virtual Officer Officer { get; set; }
        public int? PrisonerId { get; set; }
        [Required]
        [ForeignKey(nameof(PrisonerId))]
        public virtual Prisoner Prisoner { get; set; }
    }
}

//•	PrisonerId – integer, Primary Key
//•	Prisoner – the officer's prisoner (required)
//•	OfficerId – integer, Primary Key
//•	Officer – the prisoner's officer (required)
