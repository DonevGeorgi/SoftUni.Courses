﻿using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> heroes;

        public HeroRepository()
        {
            heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => heroes;

        public void Add(IHero model)
            => heroes.Add(model);

        public IHero FindByName(string name)
            => heroes.FirstOrDefault(x => x.Name == name);

        public bool Remove(IHero model)
            => heroes.Remove(heroes.FirstOrDefault(x => x.Name == model.Name));
    }
}
