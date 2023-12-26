using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;

namespace Heroes.Models
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;

        protected Weapon(string name, int durability)
        {
            Name = name;
            Durability = durability;
        }

        public string Name 
        { 
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.WeaponTypeNull);
                }

                name = value;
            }
        }

        public int Durability
        {
            get => durability;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurabilityBelowZero);
                }

                durability = value;
            }
        }

        public int DoDamage()
        {
            if (durability <= 0)
            {
                return 0;
            }
            else
            {
                durability -= 1;
            }

            if (GetType().Name == "Mace")
            {
                return 25;
            }
            else
            {
                return 20;
            }
        }
    }
}
