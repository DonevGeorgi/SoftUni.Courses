using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastre.Data.Models
{
    public class PropertyCitizen
    {
        [Required]
        public int PropertyId { get; set; }
        [ForeignKey(nameof(PropertyId))]
        public Property Property { get; set; }
        [Required]
        public int CitizenId { get; set; }
        [ForeignKey(nameof(CitizenId))]
        public Citizen Citizen { get; set; }
    }
}

//•	PropertyId – integer, Primary Key, foreign key (required)
//•	Property – Property
//•	CitizenId – integer, Primary Key, foreign key (required)
//•	Citizen – Citizen
