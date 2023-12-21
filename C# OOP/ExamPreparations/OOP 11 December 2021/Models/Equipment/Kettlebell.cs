namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double KettlebellWeights = 10000;
        private const decimal KettlebellPrice = 80;
        public Kettlebell()
            : base(KettlebellWeights, KettlebellPrice)
        {
        }
    }
}
