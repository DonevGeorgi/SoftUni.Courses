﻿using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> pilots;

        public PilotRepository()
        {
            pilots = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => pilots;

        public void Add(IPilot model)
            => pilots.Add(model);

        public bool Remove(IPilot model)
            => pilots.Remove(model);

        public IPilot FindByName(string name)
            => pilots.FirstOrDefault(n => n.FullName == name);

    }
}
