using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type,
            int laps, int capacity, int maxHosePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHosePower;

            Participants = new List<Car>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public List<Car> Participants { get; set; }

        public int Count => Participants.Count;

        public void Add(Car car)
        {
            if (!Participants.Any(x => x.LicensePlate == car.LicensePlate)
                && Participants.Count < Capacity
                && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            if (Participants.Any(x => x.LicensePlate == licensePlate))
            {
                Participants.Remove(Participants.Find(x => x.LicensePlate == licensePlate));
                return true;
            }

            return false;
        }

        public Car FindParticipant(string licensePlate)
        {
            return Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
        }

        public Car GetMostPowerfulCar()
        {
            if (Participants.Count > 0)
            {
                int max = int.MinValue;
                Car car = null;

                foreach (var participant in Participants)
                {
                    if (participant.HorsePower > max)
                    {
                        max = participant.HorsePower;
                        car = participant;
                    }
                }

                return car;
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var participant in Participants)
            {
                sb.AppendLine(participant.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
