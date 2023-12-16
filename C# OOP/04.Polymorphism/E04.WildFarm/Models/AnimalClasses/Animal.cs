using P04.WildFarm.Models.Interfaces;

namespace P04.WildFarm.Models.AnimalClasses
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract double WeightMultiplier { get; }

        public abstract IReadOnlyCollection<Type> PreferredFoods { get; }

        public abstract string ProduceSound();

        public void Eat(IFood food)
        {
            if (!PreferredFoods.Any(pf => food.GetType().Name == pf.Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * WeightMultiplier;

            FoodEaten += food.Quantity;
        }

        public override string ToString()
       => $"{GetType().Name} [{Name}, ";
    }
}
