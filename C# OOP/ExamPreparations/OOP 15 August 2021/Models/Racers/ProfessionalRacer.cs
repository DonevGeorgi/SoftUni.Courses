using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int InitialDrivingExperience = 30;
        private const string InititalRaceingBehavior = "strict";
        public ProfessionalRacer(string username, ICar car)
            : base(username, InititalRaceingBehavior, InitialDrivingExperience, car)
        {
        }
    }
}
