using P03.Raiding.Models.Interfaces;

namespace P03.Raiding.Models
{
    public abstract class Hero : IHero
    {
        public Hero(string name,int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; private set; }
        public int Power { get; private set; }

        public abstract string CastAbility();
    }
}
