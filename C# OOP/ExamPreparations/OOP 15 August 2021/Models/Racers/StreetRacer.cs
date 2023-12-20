using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int InitialDrivingExperience = 10;
        private const string InititalRaceingBehavior = "aggressive";
        public StreetRacer(string username, ICar car)
            : base(username, InititalRaceingBehavior, InitialDrivingExperience, car)
        {
        }
    }
}
