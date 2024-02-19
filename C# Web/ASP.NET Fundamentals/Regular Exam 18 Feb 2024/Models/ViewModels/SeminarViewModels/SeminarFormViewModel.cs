using SeminarHub.Data;
using SeminarHub.Models.ViewModels.CategoryViewModels;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models.ViewModels.SeminarViewModels
{
    public class SeminarFormViewModel
    {
        [Required(ErrorMessage = ErrorMessagesConstants.ReguiredErrorMessage)]
        [Display(Name = "Topic")]
        [StringLength(DataConstants.TopicMaxLength,
            MinimumLength = DataConstants.TopicMinLength,
            ErrorMessage = ErrorMessagesConstants.LengthErrorMessage)]
        public string Topic { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessagesConstants.ReguiredErrorMessage)]
        [Display(Name = "Lecturer")]
        [StringLength(DataConstants.LecturerMaxLength,
            MinimumLength = DataConstants.LecturerMinLength,
            ErrorMessage = ErrorMessagesConstants.LengthErrorMessage)]
        public string Lecturer { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessagesConstants.ReguiredErrorMessage)]
        [Display(Name = "Details")]
        [StringLength(DataConstants.DetailsMaxLength,
            MinimumLength = DataConstants.DetailsMinLength,
            ErrorMessage = ErrorMessagesConstants.LengthErrorMessage)]
        public string Details { get; set; } = string.Empty;

        [Required(ErrorMessage = ErrorMessagesConstants.ReguiredErrorMessage)]
        [Display(Name = "Date of Seminar")]
        public string DateAndTime { get; set; } = string.Empty;

        [Display(Name = "Duration")]
        [Range(DataConstants.DurationMinLength,DataConstants.DurationMaxLength,
            ErrorMessage = ErrorMessagesConstants.RangeErrorMessage)]
        public int Duration { get; set; }

        [Required(ErrorMessage = ErrorMessagesConstants.ReguiredErrorMessage)]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryInfoViewModel> Categories = new List<CategoryInfoViewModel>();
    }
}
