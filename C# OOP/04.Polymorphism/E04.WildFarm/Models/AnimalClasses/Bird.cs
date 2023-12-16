using P04.WildFarm.Models.Interfaces;

namespace P04.WildFarm.Models.AnimalClasses
{
    public abstract class Bird : Animal , IBird
    {
        protected Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString() 
            => $"{this.GetType().Name} [{base.Name}, {WingSize}, {base.Weight}, {FoodEaten}]";
    }
}
