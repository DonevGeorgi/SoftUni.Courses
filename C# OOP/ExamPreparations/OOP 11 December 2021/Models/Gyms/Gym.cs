using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;

        private List<IEquipment> equipments;
        private List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            set
            {
                capacity = value;
            }
        }

        public double EquipmentWeight
        {
            get => equipments.Sum(x => x.Weight);
        }

        public ICollection<IEquipment> Equipment => equipments;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count >= capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            athletes.Add(athlete);
        }
        public bool RemoveAthlete(IAthlete athlete)
          => athletes.Remove(athletes.FirstOrDefault(x => x.FullName == athlete.FullName));

        public void AddEquipment(IEquipment equipment)
            => equipments.Add(equipment);

        public void Exercise()
        {
            foreach (var currAthletes in athletes)
            {
                currAthletes.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {GetType().Name}:");

            if (athletes.Count > 0)
            {
                sb.Append($"Athletes: ");

                for (int i = 0; i < athletes.Count; i++)
                {
                    sb.Append(athletes[i].FullName);

                    if (i != athletes.Count - 1)
                    {
                        sb.Append(", ");
                    }
                }

                sb.AppendLine();
            }
            else
            {
                sb.AppendLine("No athletes");
            }
            sb.AppendLine($"Equipment total count: {equipments.Count}");
            sb.AppendLine($"Equipment total weight: {equipments.Sum(x => x.Weight):f2} grams");

            return sb.ToString().Trim();
        }

    }
}
