namespace SpaceStation.Models.Astronauts
{
    using System;
    using System.Text;
    using Bags.Contracts;
    using Contracts;
    using SpaceStation.Models.Bags;
    using Utilities.Messages;

    public abstract class Astronaut : IAstronaut
    {
        private string name;
        protected double oxygen;

        public Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            Bag = new Backpack();
        }

        public string Name
        {
            get => name;
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAstronautName);
                }

                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }

                oxygen = value;
            }
        }

        public bool CanBreath => oxygen > 0;

        public IBag Bag { get; set; }

        public virtual void Breath()
        {
            oxygen -= 10;
            if (oxygen < 0)
            {
                oxygen = 0;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Oxygen: {Oxygen}");
            sb.AppendLine($"Bag items: {(Bag.Items.Count > 0 ? string.Join(", ", Bag.Items) : "none")}");

            return sb.ToString().Trim();
        }
    }
}
