using System.ComponentModel.DataAnnotations;

namespace Artillery.Data.Models
{
    public class Shell
    {
        public Shell() 
        {
            Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public double ShellWeight { get; set; }
        [Required]
        [MaxLength(30)]
        public string Caliber { get; set; }
        public virtual ICollection<Gun> Guns { get; set;}
    }
}

//•	Id – integer, Primary Key
//•	ShellWeight – double in range  [2…1_680] (required)
//•	Caliber – text with length [4…30] (required)
//•	Guns – a collection of Gun
