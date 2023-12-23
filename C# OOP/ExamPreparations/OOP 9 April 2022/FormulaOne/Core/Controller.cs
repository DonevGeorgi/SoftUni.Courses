using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilots;
        private RaceRepository races;
        private FormulaOneCarRepository cars;

        public Controller()
        {
            pilots = new PilotRepository();
            races = new RaceRepository();
            cars = new FormulaOneCarRepository();
        }
        public string CreatePilot(string fullName)
        {
            IPilot currPilot = new Pilot(fullName);

            if (pilots.Models.Any(n => n.FullName == fullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            pilots.Add(currPilot);
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }
        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar currCar = null;

            if (cars.Models.Any(x => x.Model == model))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            if (type == nameof(Ferrari))
            {
                currCar = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == nameof(Williams))
            {
                currCar = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            cars.Add(currCar);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }
        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace currRace = new Race(raceName, numberOfLaps);

            if (races.Models.Any(x => x.RaceName == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            races.Add(currRace);
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (!pilots.Models.Any(n => n.FullName == pilotName) || pilots.FindByName(pilotName).Car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            else if (!cars.Models.Any(m => m.Model == carModel))
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            IPilot currPilot = pilots.FindByName(pilotName);
            IFormulaOneCar currCar = cars.FindByName(carModel);
            currPilot.AddCar(currCar);

            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, currCar.GetType().Name, carModel);
        }
        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot currPilot = pilots.FindByName(pilotFullName);
            IRace currRace = races.FindByName(raceName);

            if (!races.Models.Any(n => n.RaceName == raceName))
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            else if (currPilot == null || !currPilot.CanRace || currRace.Pilots.Any(x => x.FullName == pilotFullName))
            {
                return string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName);
            }

            currRace.AddPilot(currPilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }
        public string StartRace(string raceName)
        {
            StringBuilder sb = new StringBuilder();

            IRace currRace = races.FindByName(raceName);

            if (currRace == null)
            {
                return string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName);
            }
            else if (currRace.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            else if (currRace.TookPlace == true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            List<IPilot> winners = currRace.Pilots
                .OrderByDescending(x => x.Car.RaceScoreCalculator(currRace.NumberOfLaps))
                .ToList();

            pilots.FindByName(winners[1].FullName).WinRace();

            currRace.TookPlace = true;

            sb.AppendLine($"Pilot {winners[1].FullName} wins the {currRace.RaceName} race.");
            sb.AppendLine($"Pilot {winners[2].FullName} is second in the {currRace.RaceName} race.");
            sb.AppendLine($"Pilot {winners[3].FullName} is third in the {currRace.RaceName} race.");

            return sb.ToString().Trim();
        }
        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var currRace in races.Models)
            {
                if (currRace.TookPlace)
                {
                    sb.AppendLine(currRace.RaceInfo());
                }
            }

            return sb.ToString().Trim();
        }
        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var currPilot in pilots.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(currPilot.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
