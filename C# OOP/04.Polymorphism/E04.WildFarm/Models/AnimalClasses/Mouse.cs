using P04.WildFarm.Models.FoodClasses;
using P04.WildFarm.Models.Interfaces;

namespace P04.WildFarm.Models.AnimalClasses
{
    public class Mouse : Mammal
    {
        private const double MouseWeightMultiplier = 0.10;
        public Mouse(string name, double weight,string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods 
            => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit)};

        protected override double WeightMultiplier => MouseWeightMultiplier;

        public override string ProduceSound() => "Squeak";
    }
}
