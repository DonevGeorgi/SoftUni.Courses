using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar currCar = null;

            if (type == nameof(SuperCar))
            {
                currCar = new SuperCar(make,model,VIN,horsePower);
            }
            else if (type == nameof(TunedCar))
            {
                currCar = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            cars.Add(currCar);
            return string.Format(OutputMessages.SuccessfullyAddedCar,make,model,VIN);
        }
        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer currRacer = null;
            ICar currCar = cars.FindBy(carVIN);

            if (currCar == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }

            if (type == nameof(ProfessionalRacer))
            {
                currRacer = new ProfessionalRacer(username, currCar);
            }
            else if (type == nameof(StreetRacer))
            {
                currRacer = new StreetRacer(username, currCar);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            racers.Add(currRacer);
            return string.Format(OutputMessages.SuccessfullyAddedRacer,currRacer.Username);
        }
        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer firstRacer = racers.FindBy(racerOneUsername);
            IRacer secondRacer = racers.FindBy(racerTwoUsername);

            if (firstRacer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            else if (secondRacer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(firstRacer, secondRacer);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var currRacer in racers.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username))
            {
                sb.AppendLine(currRacer.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
