namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using SpaceStation.Utilities.Messages;

    public class Planet : IPlanet
    {
        private string name;
        private List<string> items;

        public Planet(string name, List<string> items)
        {
            Name = name;
            this.items = items;
        }
        public string Name
        {
            get => name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }

                name = value;
            }
        }

        public ICollection<string> Items => items;
    }
}