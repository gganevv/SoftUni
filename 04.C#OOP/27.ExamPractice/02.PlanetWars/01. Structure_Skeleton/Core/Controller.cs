namespace PlanetWars.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using PlanetWars.Core.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Utilities.Messages;

    public class Controller : IController
    {
        private readonly List<Planet> planets;
        public Controller()
        {
            planets = new List<Planet>();
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.FirstOrDefault(x => x.Name == name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            planets.Add(new Planet(name, budget));
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            Planet planet = planets.FirstOrDefault(x => x.Name == planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitTypeName != "AnonymousImpactUnit" && unitTypeName != "SpaceForces" && unitTypeName != "StormTroopers")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            if (planet.Army.FirstOrDefault(x => x.GetType().Name == unitTypeName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }

            IMilitaryUnit unit = null;
            if (unitTypeName == "AnonymousImpactUnit")
            {
                unit = new AnonymousImpactUnit();
            }
            if (unitTypeName == "SpaceForces")
            {
                unit = new SpaceForces();
            }
            if (unitTypeName == "StormTroopers")
            {
                unit = new StormTroopers();
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            Planet planet = planets.FirstOrDefault(x => x.Name == planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.FirstOrDefault(x => x.GetType().Name == weaponTypeName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }
            
            if (weaponTypeName != "BioChemicalWeapon" && weaponTypeName != "NuclearWeapon" && weaponTypeName != "SpaceMissiles")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weapon = null;
            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            Planet planet = planets.FirstOrDefault(x => x.Name == planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);
            planet.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string ForcesReport()
        {
            throw new NotImplementedException();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            throw new NotImplementedException();
        }
    }
}
