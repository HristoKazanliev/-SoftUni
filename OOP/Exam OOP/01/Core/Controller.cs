using PlanetWars.Core.Contracts;
using PlanetWars.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using PlanetWars.Utilities.Messages;
using PlanetWars.Models.Planets;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.MilitaryUnits;
using System.Linq;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Planets.Contracts;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planetRepository;

        public Controller()
        {
            planetRepository = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            IMilitaryUnit militaryUnit;
            var planet = planetRepository.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Any(a => a.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName,
                    planetName));
            }

            if (unitTypeName == "StormTroopers")
            {
                militaryUnit = new StormTroopers();
            }
            else if (unitTypeName == "SpaceForces")
            {
                militaryUnit = new SpaceForces();
            }
            else if (unitTypeName == "AnonymousImpactUnit")
            {
                militaryUnit = new AnonymousImpactUnit();
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            planet.Spend(militaryUnit.Cost);
            planet.AddUnit(militaryUnit);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = planetRepository.FindByName(planetName);
            IWeapon weapon;

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName,
                    planetName));
            }

            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planetRepository.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.ExistingPlanet, name));
            }

            Planet planet = new Planet(name, budget);
            planetRepository.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            var orderedPlanets = planetRepository.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name);
            var sb = new StringBuilder();
            sb.AppendLine($"***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            Planet planet1 = (Planet)planetRepository.FindByName(planetOne);
            Planet planet2 = (Planet)planetRepository.FindByName(planetTwo);

            bool attackerIsNuclear = planet1.Weapons.Any(w => w is NuclearWeapon);
            bool defenderIsNuclear = planet2.Weapons.Any(w => w is NuclearWeapon);

            IPlanet winner = null;
            IPlanet looser = null;

            if (planet1.MilitaryPower > planet2.MilitaryPower)
            {
                winner = planet1;
                looser = planet2;
            }
            else if (planet2.MilitaryPower > planet1.MilitaryPower)
            {
                winner = planet2;
                looser = planet1;
            }
            else
            {
                if (attackerIsNuclear && !defenderIsNuclear)
                {
                    winner = planet1;
                    looser = planet2;
                }
                else if (defenderIsNuclear && !attackerIsNuclear)
                {
                    winner = planet2;
                    looser = planet1;
                }
                else
                {
                    planet1.Spend(planet1.Budget / 2);
                    planet2.Spend(planet2.Budget / 2);

                    return OutputMessages.NoWinner;
                }
            }

            winner.Spend(winner.Budget / 2);
            winner.Profit(looser.Budget / 2);
            winner.Profit(looser.Army.Sum(u => u.Cost) + looser.Weapons.Sum(w => w.Price));

            planetRepository.RemoveItem(looser.Name);
            return string.Format(OutputMessages.WinnigTheWar, winner.Name, looser.Name);
        }

        public string SpecializeForces(string planetName)
        {
            if (planetRepository.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            Planet planet = (Planet)planetRepository.FindByName(planetName);
            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }

            planet.Spend(1.25);
            planet.TrainArmy();
            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
