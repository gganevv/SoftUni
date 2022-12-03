namespace NavalVessels.Core
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Models;
    using Models.Contracts;
    using Repositories;
    using Utilities.Messages;

    public class Controller : IController
    {
        private VesselRepository vesselRepository;
        private List<ICaptain> captains;

        public Controller()
        {
            vesselRepository = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            Captain captain = new Captain(fullName);
            if (captains.FirstOrDefault(x => x.FullName == fullName) == null)
            {
                captains.Add(new Captain(fullName));
                return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
            }
            else
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vesselRepository.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, name);
            }

            if (vesselType == "Submarine")
            {
                IVessel vessel = new Submarine(name, mainWeaponCaliber, speed);
                vesselRepository.Add(vessel);
                return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                IVessel vessel = new Battleship(name, mainWeaponCaliber, speed);
                vesselRepository.Add(vessel);
                return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }


        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            IVessel vessel = vesselRepository.FindByName(selectedVesselName);

            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            captain.AddVessel(vessel);
            vessel.Captain = captain;
            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName) => captains.FirstOrDefault(x => x.FullName == captainFullName).Report();


        public string VesselReport(string vesselName) => vesselRepository.FindByName(vesselName).ToString();

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vesselRepository.FindByName(vesselName);
            if (vessel != null)
            {
                if (vessel.GetType().Name == "Battleship")
                {
                    ((Battleship)vessel).ToggleSonarMode();
                    return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
                }
                else if (vessel.GetType().Name == "Submarine")
                {
                    ((Submarine)vessel).ToggleSubmergeMode();
                    return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
                }
            }

            return string.Format(OutputMessages.VesselNotFound, vesselName);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vesselRepository.FindByName(vesselName);
            if (vessel != null)
            {
                vessel.RepairVessel();
                return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
            }
            else
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = vesselRepository.FindByName(attackingVesselName);
            IVessel defendingVessel = vesselRepository.FindByName(defendingVesselName);

            if (attackingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            if (defendingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVessel);
            }

            if (attackingVessel.ArmorThickness <= 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            if (defendingVessel.ArmorThickness <= 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attackingVessel.Attack(defendingVessel);
            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }
    }
}
