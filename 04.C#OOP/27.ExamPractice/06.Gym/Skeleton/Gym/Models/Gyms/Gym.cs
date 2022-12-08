namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Athletes.Contracts;
    using Contracts;
    using Equipment.Contracts;
    using Utilities.Messages;

    public abstract class Gym : IGym
    {
        private string name;
        private readonly List<IAthlete> athletes;
        private readonly List<IEquipment> equipment;

        public Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            athletes = new List<IAthlete>();
            equipment = new List<IEquipment>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public ICollection<IEquipment> Equipment => equipment.AsReadOnly();

        public ICollection<IAthlete> Athletes => athletes.AsReadOnly();

        public double EquipmentWeight => Equipment.Sum(x => x.Weight);

        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete) => Athletes.Remove(athlete);

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} is a {GetType().Name}:");
            sb.AppendLine($"Athletes: {(Athletes.Any() ? string.Join(", ", Athletes.Select(x => x.FullName).ToList()) : "No athletes")}");
            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }

    }
}