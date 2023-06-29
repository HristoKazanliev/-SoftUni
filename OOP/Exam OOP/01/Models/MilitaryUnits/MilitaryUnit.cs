using PlanetWars.Models.MilitaryUnits.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using PlanetWars.Utilities.Messages;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel = 1;

        protected MilitaryUnit(double cost)
        {
            Cost = cost;
        }

        public double Cost
        {
            get => cost;
            private set => cost = value;
        }

        public int EnduranceLevel => enduranceLevel;

        public void IncreaseEndurance()
        {
            if (enduranceLevel > 20)
            {
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }

            enduranceLevel++;
        }
    }
}
