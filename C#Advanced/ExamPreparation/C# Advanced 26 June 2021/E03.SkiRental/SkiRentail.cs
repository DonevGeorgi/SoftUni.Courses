using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            this.data = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => data.Count;

        public Ski Add(Ski ski)
        {
            if (Capacity > data.Count)
            {
                data.Add(ski);
            }

            return null;
        }

        public bool Remove(string manufacturer, string model)
        {
            if (data.Any(m => m.Manufacturer == manufacturer && m.Model == model))
            {
                data.Remove(data.Find(x => x.Manufacturer == manufacturer && x.Model == model));
                return true;
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            int currYear = int.MinValue;
            Ski newest = null;

            foreach (Ski ski in data)
            {
                if (ski.Year > currYear)
                {
                    currYear = ski.Year;
                    newest = ski;
                }
            }

            return newest;
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");

            foreach (Ski ski in data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
