using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
        }

        public string Material { get; set; }
        public int Capacity { get; set; }

        public List<Fish> Fish = new List<Fish>();

        public int Count => Fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrEmpty(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Fish.Count == Capacity)
            {
                return "Fishing net is full.";
            }

            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            if (Fish.Any(w => w.Weight == weight))
            {
                Fish.Remove(Fish.Find(w => w.Weight == weight));
                return true;
            }

            return false;
        }

        public Fish GetFish(string fishType)
        {
            return Fish.Find(t => t.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            Fish longest = null;
            double longestLenght = double.MinValue;

            foreach (var fish in Fish)
            {
                if (fish.Length > longestLenght)
                {
                    longestLenght = fish.Length;
                    longest = fish;
                }
            }

            return longest;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {this.Material}:");

            foreach (var fish in Fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
