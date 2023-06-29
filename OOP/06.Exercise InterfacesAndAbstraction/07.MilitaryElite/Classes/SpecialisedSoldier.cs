using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enums;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public Corps Corps { get; set; }
    }
}
