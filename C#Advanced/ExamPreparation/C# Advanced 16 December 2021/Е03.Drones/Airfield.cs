using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public List<Drone> Drones = new List<Drone>();

        public int Count => Drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand)
                || !(drone.Range >= 5 && drone.Range <= 15))
            {
                return "Invalid drone.";
            }

            if (Drones.Count == Capacity)
            {
                return "Airfield is full.";
            }

            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            if (Drones.Any(x => x.Name == name))
            {
                Drones.Remove(Drones.Find(x => x.Name == name));
                return true;
            }

            return false;
        }

        public Drone FlyDrone(string name)
        {
            if (Drones.Any(x => x.Name == name))
            {
                foreach (var drone in Drones)
                {
                    if (drone.Name == name)
                    {
                        drone.Available = false;
                    }
                }

                return Drones.Find(x => x.Name == name);
            }

            return null;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = 0;

            foreach (var drone in Drones)
            {
                if (drone.Brand == brand)
                {
                    count++;
                }
            }

            Drones.RemoveAll(x => x.Brand == brand);

            if (count == 0)
            {
                return 0;
            }

            return count;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> sortedDrones = new List<Drone>();

            foreach (var drone in Drones)
            {
                if (drone.Range >= range)
                {
                    sortedDrones.Add(drone);
                    drone.Available = false;
                }
            }

            return sortedDrones;
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var drone in Drones)
            {
                if (drone.Available == true)
                {
                    sb.AppendLine(drone.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
