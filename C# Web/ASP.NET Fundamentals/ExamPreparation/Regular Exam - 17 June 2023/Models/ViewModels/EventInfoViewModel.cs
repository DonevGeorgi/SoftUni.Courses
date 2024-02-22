using Homies.Data;

namespace Homies.Models.ViewModels
{
    public class EventInfoViewModel
    {
        public EventInfoViewModel(
            int id,
            string name,
            string type,
            string organiser,
            DateTime start) 
        {
            Id = id;
            Name = name;
            Type = type;
            Organiser = organiser;
            Start = start.ToString(DataConstants.DateValidationString);
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Organiser { get; set; } = string.Empty;
        public string Start { get; set; } = string.Empty;
    }
}
