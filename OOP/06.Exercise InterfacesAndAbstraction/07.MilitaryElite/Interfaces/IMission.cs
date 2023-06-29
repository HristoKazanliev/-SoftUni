using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enums;

namespace MilitaryElite.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; set; }

        public State State { get; set; }

        void CompleteMission(string codeName);
    }
}
