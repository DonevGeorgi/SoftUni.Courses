using Heroes.IO;
using Heroes.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Models
{
    public class Map : IMap
    {
        private Writer writer;

        public string Fight(ICollection<IHero> players)
        {
            List<IHero> barbarians = players.Where(x => x.GetType().Name == "Barbarian").ToList();
            List<IHero> knights = players.Where(x => x.GetType().Name == "Knight").ToList();

            int deadBarbarians = 0;
            int deadKnights = 0;

            while (true)
            {

                if (knights.All(x => x.IsAlive == false))
                {
                    return $"The knights took {deadKnights} casualties but won the battle.";
                }
                else if(barbarians.All(x => x.IsAlive == false))
                {
                    return $"The barbarians took {deadBarbarians} casualties but won the battle.";
                }

                for (int i = 0; i < knights.Count; i++)
                {
                    if (i == barbarians.Count)
                    {
                        break;
                    }

                    if (knights[i].IsAlive)
                    {
                        barbarians[i].TakeDamage(knights[i].Weapon.DoDamage());
                    }
                    else
                    {
                        knights.RemoveAt(i);
                        deadKnights++;
                    }
                }

                for (int i = 0; i < barbarians.Count; i++)
                {
                    if (i == knights.Count)
                    {
                        break;
                    }

                    if (barbarians[i].IsAlive)
                    {
                        knights[i].TakeDamage(barbarians[i].Weapon.DoDamage());
                    }
                    else
                    {
                        barbarians.RemoveAt(i);
                        deadBarbarians++;
                    }
                }
            }
        }
    }
}
