using System;
using System.Collections.Generic;
using System.Text;
using Formula1.Models.Contracts;
using Formula1.Utilities;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private bool canRace = false;

        public Pilot(string fullName)
        {
            FullName = fullName;
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => car;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarForPilot);
                }
                car = value;
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanRace
        {
            get => canRace;
            private set 
            {
                canRace = value;
            }
        }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
