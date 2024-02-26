using SoftUniBazar.Data;
using SoftUniBazar.Models.CategoryViewModel;
using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Models.AdViewModels
{
    public class AdFormViewModel
    {
        [Required(ErrorMessage = ErrorMessagesConstants.RequierdErrorMessage)]
        [StringLength(DataConstants.AdNameMaxLength,
            MinimumLength = DataConstants.AdNameMinLength,
            ErrorMessage = ErrorMessagesConstants.LengthErrorMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessagesConstants.RequierdErrorMessage)]
        [StringLength(DataConstants.AdDescriptionMaxLength,
            MinimumLength = DataConstants.AdDescriptionMinLength,
            ErrorMessage = ErrorMessagesConstants.LengthErrorMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessagesConstants.RequierdErrorMessage)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = ErrorMessagesConstants.RequierdErrorMessage)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessagesConstants.RequierdErrorMessage)]
        public int CategoryId {  get; set; }
        public IEnumerable<CategoryFormModel> Categories { get; set; } = new List<CategoryFormModel>();
    }
}
