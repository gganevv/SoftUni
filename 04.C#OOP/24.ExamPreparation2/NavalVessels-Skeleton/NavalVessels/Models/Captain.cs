namespace NavalVessels.Models
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Contracts;
    using Utilities.Messages;

    public class Captain : ICaptain
    {
        private HashSet<IVessel> vessels;
        private string fullName;

        public Captain(string fullname)
        {
            FullName = fullname;
            vessels = new HashSet<IVessel>();
            CombatExperience = 0;
        }
        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels => vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience() => CombatExperience += 10;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");
            if (vessels.Any())
            {
                foreach (var vessel in vessels)
                {
                    Console.WriteLine(vessel);
                }
            }
            return sb.ToString().Trim();
        }
    }
}
