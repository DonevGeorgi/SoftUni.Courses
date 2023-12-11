using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            this.data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void Add(Racer Racer)
        {
            if (Capacity > data.Count)
            {
                data.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            if (data.Any(n => n.Name == name))
            {
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(a => a.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return data.FirstOrDefault(n => n.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
        }

        public int Count => data.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {Name}:");

            foreach (Racer racer in data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
