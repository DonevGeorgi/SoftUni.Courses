using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Transactions;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private int ExploredPlanets;

        private AstronautRepository astronauts;
        private PlanetRepository planets;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut currAstronaut = null;

            if (type == nameof(Biologist))
            {
                currAstronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                currAstronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                currAstronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronauts.Add(currAstronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }
        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet currPlanet = new Planet(planetName);

            foreach (var item in items)
            {
                currPlanet.Items.Add(item);
            }

            planets.Add(currPlanet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }
        public string RetireAstronaut(string astronautName)
        {
            IAstronaut currAstronaut = astronauts.FindByName(astronautName);

            if (currAstronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(currAstronaut);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> suitableAstronauts = astronauts.Models.Where(a => a.Oxygen > 60).ToList();

            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            IMission currMission = new Mission();
            IPlanet currPlanet = planets.FindByName(planetName);
            currMission.Explore(currPlanet, suitableAstronauts);
            ExploredPlanets++;

            return string.Format(OutputMessages.PlanetExplored, planetName, suitableAstronauts.Count(x => x.Oxygen == 0));
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{ExploredPlanets} planets were explored!");

            foreach (var currAstronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {currAstronaut.Name}");
                sb.AppendLine($"Oxygen: {currAstronaut.Oxygen}");
                if (currAstronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine($"Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ",currAstronaut.Bag.Items)}");
                }
            }

            return sb.ToString().Trim();
        }

    }
}
