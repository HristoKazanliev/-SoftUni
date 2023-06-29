using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
