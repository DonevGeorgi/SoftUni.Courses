namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double InitialOxygen = 70;
        public Biologist(string name)
            : base(name, InitialOxygen)
        {

        }

        public override void Breath()
        {
            if (base.Oxygen - 5 <= 0)
            {
                base.Oxygen = 0;
            }
            else
            {
                base.Oxygen -= 5;
            }
        }
    }
}
