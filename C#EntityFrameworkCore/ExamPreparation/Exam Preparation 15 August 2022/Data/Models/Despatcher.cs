using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        public Despatcher() 
        {
            Trucks = new HashSet<Truck>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public virtual ICollection<Truck> Trucks { get; set; }

    }
}

