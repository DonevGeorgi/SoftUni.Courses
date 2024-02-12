using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck() 
        {
            ClientsTrucks = new HashSet<ClientTruck>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(8)]
        [RegularExpression(@"[A-Z]{2}[0-9]{4}[A-Z]{2}")]
        public string RegistrationNumber { get; set; }
        [Required]
        [StringLength(17)]
        public string VinNumber { get; set; }
        [Required]
        public int TankCapacity { get; set; }
        [Required]
        public int CargoCapacity { get; set; }
        [Required]
        public CategoryType CategoryType { get; set; }
        [Required]
        public MakeType MakeType { get; set; }
        [Required]
        public int DespatcherId { get; set; }
        [ForeignKey(nameof(DespatcherId))]
        public virtual Despatcher Despatcher { get; set; }
        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	RegistrationNumber – text with length 8. First two characters
//are upper letters [A-Z], followed by four digits and the last
//two characters are upper letters [A-Z] again.
//•	VinNumber – text with length 17 (required)
