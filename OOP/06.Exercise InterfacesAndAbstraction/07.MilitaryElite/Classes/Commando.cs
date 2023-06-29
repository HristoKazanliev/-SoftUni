using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public List<IMission> Missions { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");
            foreach (var mission in this.Missions)
            {
                sb.AppendLine($"  {mission}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
