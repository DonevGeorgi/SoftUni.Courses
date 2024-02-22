using Homies.Data;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models.ViewModels
{
    public class EventFormViewModel
    {
        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(DataConstants.EventNameMaxLength,
            MinimumLength = DataConstants.EventNameMinLength,
            ErrorMessage = ErrorMessages.LengthErrorMessage)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        [StringLength(DataConstants.EventDescriptionMaxLength,
            MinimumLength = DataConstants.EventDescriptionMinLength,
            ErrorMessage = ErrorMessages.LengthErrorMessage)]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        public string Start { get; set; } = string.Empty;
        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        public string End { get; set; } = string.Empty;
        [Required(ErrorMessage = ErrorMessages.RequiredErrorMessage)]
        public int TypeId { get; set; }
        public IEnumerable<TypeFormViewModel> Types { get; set; } = new List<TypeFormViewModel>();
    }
}
