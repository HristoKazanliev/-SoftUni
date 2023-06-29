using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private List<string> targets;

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            ArmorThickness = armorThickness;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            captain = null;
            targets = new List<string>();
        }

        public string Name
        {
            get => name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
            set 
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                captain = value;
            }
        }
        public double ArmorThickness
        {
            get => armorThickness;
            set => armorThickness = value;
        }

        public double MainWeaponCaliber
        {
            get => mainWeaponCaliber;
            protected set => mainWeaponCaliber = value;
        }


        public double Speed
         {
            get => speed;
            protected set => speed = value;
        }

        public ICollection<string> Targets => targets;

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;

            if (target.ArmorThickness <0)
            {
                target.ArmorThickness = 0;
            }

            targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            string targetsCount = targets.Count == 0 ? "None" : string.Join(", ", targets);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            sb.AppendLine($" *Targets: {targetsCount}");

            return sb.ToString().TrimEnd();
        }
    }
}
