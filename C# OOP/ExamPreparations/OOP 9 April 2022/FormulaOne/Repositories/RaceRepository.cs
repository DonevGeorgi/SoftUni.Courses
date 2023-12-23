using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }

        public IReadOnlyCollection<IRace> Models => races;

        public void Add(IRace model)
            => races.Add(model);
        public bool Remove(IRace model)
            => races.Remove(model);

        public IRace FindByName(string name)
            => races.FirstOrDefault(n => n.RaceName == name);

    }
}
