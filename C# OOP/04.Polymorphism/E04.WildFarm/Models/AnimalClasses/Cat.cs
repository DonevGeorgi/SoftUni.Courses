using P04.WildFarm.Models.FoodClasses;

namespace P04.WildFarm.Models.AnimalClasses
{
    public class Cat : Feline
    {
        private const double CatWeightMultiplier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type> {typeof(Meat),typeof(Vegetable)};

        protected override double WeightMultiplier => CatWeightMultiplier;

        public override string ProduceSound() => "Meow";
    }
}
