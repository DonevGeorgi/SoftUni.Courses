using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;
        private bool carRace;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        { 
            get => fullName;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }

                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => car;
            private set 
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }

                car = value; 
            }
        }

        public int NumberOfWins
        {
            get => numberOfWins;
            private set
            {
                numberOfWins = value;
            }
        }

        public bool CanRace
        {
            get => carRace;
            private set
            {
               carRace = value;
            }
        }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
            => NumberOfWins += 1;

        public override string ToString()
            => $"Pilot {FullName} has {NumberOfWins} wins.";
    }
}
