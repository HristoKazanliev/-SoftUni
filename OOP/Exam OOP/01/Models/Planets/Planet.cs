using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PlanetWars.Models.MilitaryUnits;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private UnitRepository unitRepository;
        private WeaponRepository weaponRepository;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            unitRepository = new UnitRepository();
            weaponRepository = new WeaponRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower => TotalAmount();
       
        public IReadOnlyCollection<IMilitaryUnit> Army => unitRepository.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weaponRepository.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            unitRepository.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weaponRepository.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            string unitsCount = Army.Count == 0 ? "No units" : string.Join(", ", Army.Select(a => a.GetType().Name));
            string combatEquipment = Weapons.Count == 0 ? "No weapons" : string.Join(", ", Weapons.Select(a => a.GetType().Name));

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");
            sb.AppendLine($"--Forces: {unitsCount}");
            sb.AppendLine($"--Combat equipment: {combatEquipment}");
            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().TrimEnd();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var item in unitRepository.Models)
            {
                item.IncreaseEndurance();
            }
        }

        private double TotalAmount()
        {
            double sumOfUnitEndurances = Army.Sum(m => m.EnduranceLevel);
            double sumOfWeaponDestructionLevels = Weapons.Sum(w => w.DestructionLevel);
            double totalAmount = sumOfUnitEndurances + sumOfWeaponDestructionLevels;

            if (Army.Any(u => u.GetType().Name == "AnonymousImpactUnit"))
            {
                totalAmount *= 1.3;
            }

            if (Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
            {
                totalAmount *= 1.45;
            }

            return Math.Round(totalAmount, 3);
        }
    }
}
