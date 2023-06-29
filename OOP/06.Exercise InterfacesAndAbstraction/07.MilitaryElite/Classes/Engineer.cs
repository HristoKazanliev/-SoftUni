using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            Repairs = new List<IRepair>();
        }

        public List<IRepair> Repairs { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");
            foreach (var repair in this.Repairs)
            {
                sb.AppendLine($"  {repair}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
