using Contacts.Data;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Models.ViewModels
{
    public class ContactsFormViewModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(DataConstants.FirstNameMaxLength,
            MinimumLength = DataConstants.FirstNameMinLength,
            ErrorMessage = ErrorMessages.FieldLengthError)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(DataConstants.FirstNameMaxLength,
            MinimumLength = DataConstants.LastNameMinLength,
            ErrorMessage = ErrorMessages.FieldLengthError)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [EmailAddress]
        [StringLength(DataConstants.EmailMaxLength,
            MinimumLength = DataConstants.EmailMinLength,
            ErrorMessage = ErrorMessages.FieldLengthError)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [Phone]
        [StringLength(DataConstants.PhoneNumberMaxLength,
            MinimumLength = DataConstants.PhoneNumberMinLength,
            ErrorMessage = ErrorMessages.FieldLengthError)]
        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        public string Website { get; set; } = string.Empty;
    }
}
