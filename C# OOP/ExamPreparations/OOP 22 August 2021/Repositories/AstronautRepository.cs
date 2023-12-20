using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> spaceStation;

        public AstronautRepository()
        {
            spaceStation = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => spaceStation;

        public void Add(IAstronaut model)
            => spaceStation.Add(model);
        public bool Remove(IAstronaut model)
            => spaceStation.Remove(spaceStation.FirstOrDefault(x => x.Name == model.Name));

        public IAstronaut FindByName(string name)
            => spaceStation.FirstOrDefault(x => x.Name == name);

    }
}
