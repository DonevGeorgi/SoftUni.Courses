using P04.WildFarm.Models.Interfaces;

namespace P04.WildFarm.Factories.Interface
{
    public interface IAnimalFactory
    {
        IAnimal Create(string[] Args);
    }
}
