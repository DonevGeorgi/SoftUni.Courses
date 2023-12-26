using Heroes.Core.Contracts;
using Heroes.Models;
using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using Heroes.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IWeapon> weapons;
        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.Models.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.HeroAlreadyExist,name);
            }

            IHero currHero = null;

            if (type == nameof(Barbarian))
            {
                currHero = new Barbarian(name,health,armour);
                heroes.Add(currHero);
                return string.Format(OutputMessages.SuccessfullyAddedBarbarian, name);
            }
            else if (type == nameof(Knight))
            {
                currHero = new Knight(name, health, armour);
                heroes.Add(currHero);
                return string.Format(OutputMessages.SuccessfullyAddedKnight,name);
            }
            else
            {
                return string.Format(OutputMessages.HeroTypeIsInvalid);
            }
        }
        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.Models.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.WeaponAlreadyExists, name);
            }

            IWeapon currWeapon = null;

            if (type == nameof(Mace))
            {
                currWeapon = new Mace(name,durability);
                weapons.Add(currWeapon);
                return string.Format(OutputMessages.WeaponAddedSuccessfully, type.ToLower(), name);
            }
            else if (type == nameof(Claymore))
            {
                currWeapon = new Claymore(name, durability);
                weapons.Add(currWeapon);
                return string.Format(OutputMessages.WeaponAddedSuccessfully,type.ToLower(),name);
            }
            else
            {
                return string.Format(OutputMessages.WeaponTypeIsInvalid);
            }
        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            if (!heroes.Models.Any(x => x.Name == heroName))
            {
                return string.Format(OutputMessages.HeroDoesNotExist, heroName);
            }
            else if (!weapons.Models.Any(x => x.Name == weaponName))
            {
                return string.Format(OutputMessages.WeaponDoesNotExist, weaponName);
            }
            
            IHero currHero = heroes.FindByName(heroName);
            IWeapon currWeapon = weapons.FindByName(weaponName);

            if (currHero.Weapon != null)
            {
                return string.Format(OutputMessages.HeroAlreadyHasWeapon, heroName);
            }

            currHero.AddWeapon(currWeapon);
            weapons.Remove(currWeapon);

            return string.Format(OutputMessages.WeaponAddedToHero,heroName,nameof(weaponName));
        }
        public string StartBattle()
        {
            IMap currMap = new Map();
            List<IHero> allPlayers = heroes.Models.ToList();

            return currMap.Fight(allPlayers);
        }
        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var currHero in heroes.Models
                .OrderBy(x => nameof(x))
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Name))
            {
                sb.AppendLine($"{currHero.GetType().Name}: {currHero.Name}");
                sb.AppendLine($"--Health: {currHero.Health}");
                sb.AppendLine($"--Armour: {currHero.Armour}");
                sb.AppendLine($"--Weapon: {currHero.Weapon.Name}/Unarmed");
            }

            return sb.ToString().Trim();
        }
    }
}
