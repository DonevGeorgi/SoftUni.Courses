using P03.Raiding.Factory.Interfaces;
using P03.Raiding.Models;
using P03.Raiding.Models.Interfaces;

namespace P03.Raiding.Factory
{
    public class BornHero : IFactory
    {
        public IHero Create(string type, string name)
        {
            IHero newHero = null;

            if (type == "Druid")
            {
                Druid druid = new(name);
                newHero = druid;
            }
            else if (type == "Paladin")
            {
                Paladin paladin = new(name);
                newHero = paladin;
            }
            else if (type == "Rogue")
            {
                Rogue rogue = new(name);
                newHero = rogue;
            }
            else if (type == "Warrior")
            {
                Warrior warrior = new(name);
                newHero = warrior;
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }

            return newHero;
        }
    }
}
