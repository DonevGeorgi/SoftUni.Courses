using P04.WildFarm.Models.Interfaces;

namespace P04.WildFarm.Models.AnimalClasses
{
    public abstract class Feline : Mammal,IFeline
    {
        protected Feline(string name, double weight, string livingRegion,string breed)
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString() 
            => $"{this.GetType().Name} [{base.Name}, {Breed}, {base.Weight}, {base.LivingRegion}, {FoodEaten}]";
    }
}
