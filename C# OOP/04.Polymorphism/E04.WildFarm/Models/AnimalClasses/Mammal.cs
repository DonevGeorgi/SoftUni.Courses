using P04.WildFarm.Models.Interfaces;

namespace P04.WildFarm.Models.AnimalClasses
{
    public abstract class Mammal : Animal , IMammal
    {
        protected Mammal(string name, double weight,string livingRegion) 
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString() 
            => $"{this.GetType().Name} [{base.Name}, {base.Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
