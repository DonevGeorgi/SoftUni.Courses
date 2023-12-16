using P04.WildFarm.Models.Interfaces;

namespace P04.WildFarm.Factories.Interface
{
    public interface IFoodFactory
    {
        IFood Create(string[] Args);
    }
}
