using Artillery.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.Data.Models
{
    public class CountryGun
    {
        [Required]
        public int CountryId { get; set; }
        [Required]
        [ForeignKey(nameof(CountryId))]
        public Country? Country { get; set; }
        [Required]
        public int GunId { get; set; }
        [Required]
        [ForeignKey(nameof(GunId))]
        public Gun? Gun { get; set;}
    }
}

//•	CountryId – Primary Key integer, foreign key (required)
//•	GunId – Primary Key integer, foreign key (required)
