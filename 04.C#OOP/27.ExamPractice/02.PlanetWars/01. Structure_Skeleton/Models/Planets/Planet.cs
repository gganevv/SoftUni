using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private UnitRepository units;
        private WeaponRepository weapons;
        private string name;
        private double budget;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }

                budget = value;
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => units.Models;
        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public double MilitaryPower => CalculateMilitaryPower();

        public double CalculateMilitaryPower()
        {
            double totalAmount = Army.Sum(x => x.EnduranceLevel) + Weapons.Sum(x => x.DestructionLevel);
            if (Army.FirstOrDefault(x => x.GetType().Name == "AnonymousImpactUnit") != null)
            {
                totalAmount *= 1.3;
            }
            if (Weapons.FirstOrDefault(x => x.GetType().Name == "NuclearWeapon") != null)
            {
                totalAmount *= 1.45;
            }

            return Math.Round(totalAmount, 3);
        }

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine($"--Forces: {(Army.Count > 0 ? string.Join(", ", Army.Select(x => x.GetType().Name)) : "No units")}");
            sb.AppendLine($"--Combat equipment: {(Weapons.Count > 0 ? string.Join(", ", Weapons.Select(x => x.GetType().Name)) : "No weapons")}");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().Trim();
        }
    }
}
