using SeminarHub.Data;

namespace SeminarHub.Models.ViewModels.SeminarViewModels
{
    public class SeminarDeleteViewModel
    {
        public int Id { get; set; }
        public string Topic { get; set; } = string.Empty;
        public DateTime DateAndTime { get; set; }
    }
}
