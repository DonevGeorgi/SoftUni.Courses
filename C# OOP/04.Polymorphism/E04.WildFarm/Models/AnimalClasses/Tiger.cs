﻿using P04.WildFarm.Models.FoodClasses;
using P04.WildFarm.Models.Interfaces;

namespace P04.WildFarm.Models.AnimalClasses
{
    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1;

        public Tiger(string name, double weight,string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
        => new HashSet<Type>() { typeof(Meat) };

        protected override double WeightMultiplier
            => TigerWeightMultiplier;

        public override string ProduceSound() => "ROAR!!!";

    }
}
