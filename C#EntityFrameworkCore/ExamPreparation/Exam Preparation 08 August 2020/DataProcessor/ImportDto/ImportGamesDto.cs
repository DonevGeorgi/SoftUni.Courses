using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ImportDto
{
    public class ImportGamesDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0,1000000)]
        public decimal Price { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
        [Required]
        public string Developer { get; set; }
        [Required]
        public string Genre { get; set; }
        public string[] Tags { get; set; }
    }
}
