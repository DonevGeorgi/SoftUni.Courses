using P04.WildFarm.Models.FoodClasses;
using P04.WildFarm.Models.Interfaces;

namespace P04.WildFarm.Models.AnimalClasses
{
    public class Dog : Mammal
    {
        private const double DogWeightMultiplier = 0.40;
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods 
            => new HashSet<Type> { typeof(Meat) };

        protected override double WeightMultiplier => DogWeightMultiplier;

        public override string ProduceSound() => "Woof!";
    }
}
