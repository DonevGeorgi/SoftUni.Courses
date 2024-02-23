using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Data.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(DataConstants.FirstNameMaxLength)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(DataConstants.LastNameMaxLength)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(DataConstants.EmailMaxLength)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [RegularExpression(DataConstants.RegularExpresionForPhone)]
        [MaxLength(DataConstants.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [Required]
        [RegularExpression(DataConstants.WebsiteRegularExpresion)]
        public string Website {  get; set; } = string.Empty;
        public IEnumerable<IdentityUser> ApplicationUserContact { get; set; } = new List<IdentityUser>();
    }
}
