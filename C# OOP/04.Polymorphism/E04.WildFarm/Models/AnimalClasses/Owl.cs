using P04.WildFarm.Models.FoodClasses;
using P04.WildFarm.Models.Interfaces;

namespace P04.WildFarm.Models.AnimalClasses
{
    public class Owl : Bird
    {
        private const double OwlWeightMultiplier = 0.25;

        public Owl(string name, double weight,double wingSize)
            : base(name, weight,wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods 
            => new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplier => OwlWeightMultiplier;

        public override string ProduceSound() => "Hoot Hoot";
    }
}
