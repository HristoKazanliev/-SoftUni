using NavalVessels.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using NavalVessels.Utilities.Messages;
using NavalVessels.Repositories;
using NavalVessels.Models.Contracts;
using System.Linq;
using NavalVessels.Models;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vesselRepository;
        private List<ICaptain> captains;

        public Controller()
        {
            vesselRepository = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            if (captain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            var vessel = vesselRepository.FindByName(selectedVesselName);
            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            captains.Add(captain);
            vessel.Captain = captain;
            captain.Vessels.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = vesselRepository.FindByName(attackingVesselName);
            var defendingVessel = vesselRepository.FindByName(defendingVesselName);

            if (attackingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            if (defendingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            double attackingVesselArmor = attackingVessel.ArmorThickness;
            double defendingVesselArmor = defendingVessel.ArmorThickness;

            if (attackingVesselArmor == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            if (defendingVesselArmor == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            var captain = captains.Find(c => c.FullName == captainFullName);

            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            if (captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            Captain captain = new Captain(fullName);
            captains.Add(captain);

            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = null;

            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return string.Format(OutputMessages.InvalidVesselType);
            }

            if (vesselRepository.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            vesselRepository.Add(vessel);

            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string ServiceVessel(string vesselName)
        {
            var vessel = vesselRepository.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = vesselRepository.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel.GetType().Name == "Battleship")
            {
                Battleship battleship = (Battleship)vessel;
                battleship.ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                Submarine submarine = (Submarine)vessel;
                submarine.ToggleSubmergeMode();
                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
        }

        public string VesselReport(string vesselName)
        {
            var vessel = vesselRepository.FindByName(vesselName);

            return vessel.ToString();
        }
    }
}
