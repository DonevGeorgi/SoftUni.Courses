using P04.WildFarm.Models.FoodClasses;
using P04.WildFarm.Models.Interfaces;

namespace P04.WildFarm.Models.AnimalClasses
{
    public class Hen : Bird
    {
        private const double HenWeightMultiplier = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods 
            => new HashSet<Type>() { typeof(Fruit), typeof(Meat), typeof(Vegetable), typeof(Seeds)};

        protected override double WeightMultiplier => HenWeightMultiplier;

        public override string ProduceSound() => "Cluck";
    }
}
