namespace NavalVessels.Models
{
    using System;
    
    using Contracts;
    public class Battleship : Vessel, IBattleship
    {
        private const double DEFAULT_ARMOR_THICKNES = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, DEFAULT_ARMOR_THICKNES)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public override void RepairVessel()
        {
            ArmorThickness = DEFAULT_ARMOR_THICKNES;
        }

        public void ToggleSonarMode()
        {
            if (SonarMode == false)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
                SonarMode = true;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
                SonarMode = false;
            }
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $" *Sonar mode: {(SonarMode ? "ON" : "OFF")}";
        }
    }
}
