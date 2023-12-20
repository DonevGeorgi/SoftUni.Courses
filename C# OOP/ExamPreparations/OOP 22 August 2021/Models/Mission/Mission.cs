using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            int nextItem = 0;

            List<string> copyItems = planet.Items.ToList();

            foreach (var currAstronaut in astronauts)
            {
                if (currAstronaut.Oxygen <= 0)
                {
                    continue;
                }

                while (true)
                {
                    if (copyItems.Count == 0)
                    {
                        return;
                    }
                    string currItem = copyItems[nextItem];
                    currAstronaut.Breath();
                    currAstronaut.Bag.Items.Add(currItem);
                    planet.Items.Remove(currItem);
                    copyItems.RemoveAt(nextItem);

                    if (currAstronaut.Oxygen == 0)
                    {
                        break;
                    }
                }
            }
        }
    }
}
