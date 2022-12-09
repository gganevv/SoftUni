﻿namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using SpaceStation.Utilities.Messages;

    public class Planet : IPlanet
    {
        private string name;

        public Planet(string name)
        {
            Name = name;
            Items = new List<string>();
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

        public ICollection<string> Items { get; set; }
    }
}