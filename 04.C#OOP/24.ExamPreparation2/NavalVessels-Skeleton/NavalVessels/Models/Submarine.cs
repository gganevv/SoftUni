namespace NavalVessels.Models
{
    using Contracts;
    using System;

    public class Submarine : Vessel, ISubmarine
    {
        private const double DEFAULT_ARMOR_THICKNES = 200;
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, DEFAULT_ARMOR_THICKNES)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public override void RepairVessel()
        {
            ArmorThickness = DEFAULT_ARMOR_THICKNES;
        }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == false)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
                SubmergeMode = true;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
                SubmergeMode = false;
            }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $" *Submerge mode: {(SubmergeMode ? "ON" : "OFF")}";
        }
    }
}
