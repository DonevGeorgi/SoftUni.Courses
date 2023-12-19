using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);

            }
            else if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.RaceCannotBeCompleted);
            }

            double driverOneChances = 0;
            double driverOneMultip = 0;

            switch (racerOne.RacingBehavior)
            {
                case "strict": driverOneMultip = 1.2; break;
                case "aggressive": driverOneMultip = 1.1; break;
            }

            driverOneChances = racerOne.Car.HorsePower * racerOne.DrivingExperience * driverOneMultip;

            double driverTwoChances = 0;
            double driverTwoMultip = 0;

            switch (racerTwo.RacingBehavior)
            {
                case "strict": driverTwoMultip = 1.2; break;
                case "aggressive": driverTwoMultip = 1.1; break;
            }

            driverTwoChances = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * driverTwoMultip;

            racerOne.Race();
            racerTwo.Race();

            if (driverOneChances > driverTwoChances)
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
        }
    }
}
