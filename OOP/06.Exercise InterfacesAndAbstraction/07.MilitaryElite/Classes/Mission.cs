using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Enums;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Classes
{
    class Mission : IMission
    {
        public Mission(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; set; }

        public State State { get; set; }

        public void CompleteMission(string codeName)
        {
            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
