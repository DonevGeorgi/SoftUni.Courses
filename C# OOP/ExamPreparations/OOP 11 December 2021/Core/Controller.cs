using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym currGym = null;

            if (gymType == nameof(BoxingGym))
            {
                currGym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                currGym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            gyms.Add(currGym);
            return string.Format(OutputMessages.SuccessfullyAdded,gymType);
        }
        public string AddEquipment(string equipmentType)
        {
            IEquipment currEquipment = null;

            if (equipmentType == nameof(BoxingGloves))
            {
                currEquipment = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                currEquipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            equipment.Add(currEquipment);
            return string.Format(OutputMessages.SuccessfullyAdded,equipmentType);
        }
        public string InsertEquipment(string gymName, string equipmentType)
        {
            if (!equipment.Models.Any(x => x.GetType().Name == equipmentType))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment,equipmentType));
            }

            IEquipment currEquipment = equipment.Models.FirstOrDefault(x => x.GetType().Name == equipmentType);
            IGym currGym = gyms.FirstOrDefault(x => x.Name == gymName);
            currGym.AddEquipment(currEquipment);
            equipment.Remove(currEquipment);

            return string.Format(OutputMessages.EntityAddedToGym,equipmentType,gymName);
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete currAthlete = null;

            if (athleteType == nameof(Boxer))
            {
                currAthlete = new Boxer(athleteName,motivation,numberOfMedals);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                currAthlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            IGym currGym = gyms.FirstOrDefault(x => x.Name == gymName);

            if (currAthlete.GetType().Name == nameof(Boxer) && currGym.GetType().Name == nameof(BoxingGym))
            {
                currGym.AddAthlete(currAthlete);
            }
            else if (currAthlete.GetType().Name == nameof(Weightlifter) && currGym.GetType().Name == nameof(WeightliftingGym))
            {
                currGym.AddAthlete(currAthlete);
            }
            else
            {
                return OutputMessages.InappropriateGym;
            }

            return string.Format(OutputMessages.EntityAddedToGym,athleteType,gymName);
        }
        public string TrainAthletes(string gymName)
        {
            IGym currGym = gyms.FirstOrDefault(x => x.Name == gymName);

            foreach (var currAthlete in currGym.Athletes)
            {
                currAthlete.Exercise();
            }

            return $"Exercise athletes: {currGym.Athletes.Count}.";
        }
        public string EquipmentWeight(string gymName)
        {
            IGym currGym = gyms.FirstOrDefault(x => x.Name == gymName);

            double value = 0;

            foreach (var currWeight in currGym.Equipment)
            {
                value += currWeight.Weight;
            }

            return $"The total weight of the equipment in the gym {gymName} is {value} grams.";
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var currGym in gyms)
            {
                sb.AppendLine(currGym.GymInfo());
            }

            return sb.ToString().Trim();
        }

    }
}
