using Microsoft.AspNetCore.Identity;
using SeminarHub.Data;
using SeminarHub.Data.Models;

namespace SeminarHub.Models.ViewModels.SeminarViewModels
{
    public class SeminarInfoViewModel
    {
        public SeminarInfoViewModel(
            int id,
            string topic,
            string lecturer,
            Category category,
            DateTime dateAndTime,
            IdentityUser organizer
            ) 
        {
            Id = id;
            Topic = topic;
            Lecturer = lecturer;
            Category = category.Name;
            DateAndTime = dateAndTime.ToString(DataConstants.DataFormat);
            Organizer = organizer.UserName;
        }

        public int Id { get; set; }
        public string Topic { get; set; }
        public string Lecturer { get; set; }
        public string Category { get; set; }
        public string DateAndTime { get; set; }
        public string Organizer { get; set; }
    }
}
