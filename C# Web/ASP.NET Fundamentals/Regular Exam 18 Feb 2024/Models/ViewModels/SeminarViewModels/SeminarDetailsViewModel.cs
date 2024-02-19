using Microsoft.AspNetCore.Identity;
using SeminarHub.Data;
using SeminarHub.Data.Models;

namespace SeminarHub.Models.ViewModels.SeminarViewModels
{
    public class SeminarDetailsViewModel
    {
        public SeminarDetailsViewModel(
            int id,
            string topic,
            string lecturer,
            string details,
            Category category,
            DateTime dateAndTime,
            int duration,
            IdentityUser organizer
            ) 
        {
            Id = id;
            Topic = topic; 
            Lecturer = lecturer;
            Details = details;
            Category = category.Name;
            DateAndTime = dateAndTime.ToString(DataConstants.DataFormat);
            Duration = duration.ToString();
            Organizer = organizer.UserName;
        }

        public int Id { get; set; }
        public string Topic { get; set; }
        public string Lecturer { get; set; }
        public string Details { get; set; }
        public string Category { get; set; }
        public string DateAndTime { get; set; }
        public string Duration { get; set; }
        public string Organizer { get; set; }
    }
}
