using P03.Raiding.Models.Interfaces;

namespace P03.Raiding.Factory.Interfaces
{
    public interface IFactory
    {
        IHero Create(string type, string name);
    }
}
