using System;
using System.Collections.Generic;
using System.Text;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThickness = 200;
        private bool submergeMode = false;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public bool SubmergeMode => submergeMode;

        public override void RepairVessel()
        {
            ArmorThickness = InitialArmorThickness;
        }

        public void ToggleSubmergeMode()
        {
            switch (SubmergeMode)
            {
                case false:
                    submergeMode = true;
                    MainWeaponCaliber += 40;
                    Speed -= 4;
                    break;
                case true:
                    submergeMode = false;
                    MainWeaponCaliber -= 40;
                    Speed += 4;
                    break;
            }
        }

        public override string ToString()
        {
            string submergeMode = SubmergeMode == true ? "ON" : "OFF";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {submergeMode}");

            return sb.ToString().TrimEnd();
        }
    }
}
