namespace P04.WildFarm.Models.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        string ProduceSound();
        int FoodEaten { get; }
        void Eat(IFood food);
    }
}
