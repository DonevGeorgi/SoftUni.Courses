using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;

namespace Heroes.Models
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;
        

        protected Hero(string name, int health, int armour) 
        {
            Name = name;
            Health = health;
            Armour = armour; 
            IsAlive = true;
        }

        public string Name 
        { 
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.HeroNameNull);
                }

                name = value;
            }
        }

        public int Health 
        { 
            get => health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroHealthBelowZero);
                }

                health = value;
            }
        }

        public int Armour
        {
            get => armour;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeroArmourBelowZero);
                }

                armour = value;
            }
        }

        public bool IsAlive { get; private set; }

        public IWeapon Weapon
        {
            get => weapon;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.WeaponNull);
                }

                weapon = value;
            }
        }

        public void AddWeapon(IWeapon weapon)
            => this.weapon = weapon;

        public void TakeDamage(int points)
        {
            if (armour > 0)
            {
                if (armour - points <= 0)
                {
                    points -= armour;
                    armour = 0;
                }
                else
                {
                    armour -= points;
                }
            }

            if (health > 0 && armour <= 0)
            {
                if (health - points <= 0)
                {
                    health = 0;
                }
                else
                {
                    health -= points;
                }
            }

            if (health <= 0)
            {
                IsAlive = false;
            }
        }
    }
}
