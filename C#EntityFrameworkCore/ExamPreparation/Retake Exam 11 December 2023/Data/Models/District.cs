using Cadastre.Data.Enumerations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.Data.Models
{
    public class District
    {
        public District() 
        {
            Properties = new List<Property>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        [Required]
        [StringLength(8)]
        public string PostalCode { get; set; }
        [Required]
        public Region Region { set; get; }  
        public virtual ICollection<Property> Properties { set; get; }
    }
}

//•	Id – integer, Primary Key
//•	Name – text with length [2, 80] (required)
//•	PostalCode – text with length 8.
//All postal codes must have the following structure:starting with two capital letters, followed by e dash '-',
//followed by five digits. Example: SF - 10000(required)  ^[A-Z]{2}\-\d{5}$
//•	Region – Region enum (SouthEast = 0, SouthWest, NorthEast, NorthWest)(required)
//•	Properties - collection of type Property
