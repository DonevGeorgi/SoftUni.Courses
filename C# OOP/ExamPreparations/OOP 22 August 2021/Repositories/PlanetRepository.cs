using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> plantes;

        public PlanetRepository()
        {
            plantes = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => plantes;

        public void Add(IPlanet model)
            => plantes.Add(model);
        public bool Remove(IPlanet model)
            => plantes.Remove(plantes.FirstOrDefault(x => x.Name == model.Name));
        public IPlanet FindByName(string name)
            => plantes.FirstOrDefault(x => x.Name == name);

    }
}
