namespace Heroes.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Heroes.Models.Map;
    using Models.Contracts;
    using Models.Heroes;
    using Models.Weapons;
    using Repositories;
    using Utilities;

    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            string result = string.Empty;
            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.HERO_ALREADY_EXISTS_EXCEPTION, name));
            }

            if (type != "Barbarian" && type != "Knight")
            {
                throw new InvalidOperationException(ExceptionMessages.INVALID_HERO_TYPE_EXCEPTION);
            }

            if (type == "Barbarian")
            {
                heroes.Add(new Barbarian(name, health, armour));
                result = string.Format(OutputMessages.SUCCESSFULLY_ADDED_BARBARIAN, name);
            }
            else if (type == "Knight")
            {
                heroes.Add(new Knight(name, health, armour));
                result = string.Format(OutputMessages.SUCCESSFULLY_ADDED_KNIGHT, name);
            }

            return result;
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WEAPON_ALREADY_EXIST_EXCEPTION, name));
            }

            if (type != "Claymore" && type != "Mace")
            {
                throw new InvalidOperationException(ExceptionMessages.INVALID_WEAPON_TYPE_EXCEPTION);
            }

            if (type == "Claymore")
            {
                weapons.Add(new Claymore(name, durability));
            }
            else if (type == "Mace")
            {
                weapons.Add(new Mace(name, durability));
            }

            return string.Format(OutputMessages.SUCCESSFULLY_ADDED_WEAPON, type.ToLower(), name);
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {
            IHero hero = heroes.FindByName(heroName);
            if (hero == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.HERO_DOES_NOT_EXIST_EXCEPTION, heroName));
            }

            IWeapon weapon = weapons.FindByName(weaponName);
            if (weapon == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WEAPON_DOES_NOT_EXIST_EXCEPTION, weaponName));
            }

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.HERO_ALREADY_HAVE_WEAPON, heroName));
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);

            return string.Format(OutputMessages.SUCCESSFULLY_ADDED_WEAPON_TO_HERO, heroName, weapon.GetType().Name.ToLower());
        }

        public string StartBattle()
        {
            Map map = new Map();
            ICollection<IHero> heroes = this.heroes.Models.Where(x => x.IsAlive && x.Weapon != null).ToList();
            return map.Fight(heroes);
        }

        public string HeroReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in heroes.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Name))
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().Trim();
        }

        
    }
}
