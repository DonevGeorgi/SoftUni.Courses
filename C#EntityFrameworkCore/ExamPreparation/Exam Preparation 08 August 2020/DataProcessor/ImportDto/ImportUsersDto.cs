using System.ComponentModel.DataAnnotations;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ImportDto
{
    public class ImportUsersDto
    {
        [Required]
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$")]
        public string FullName { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Range(3,103)]
        public int Age { get; set; }
        public ImportCardsDto[] Cards { get; set; }
    }
}
