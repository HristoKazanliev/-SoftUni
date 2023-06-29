using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public abstract class BaseHero
    {
        protected BaseHero(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public abstract int Power { get; }

        public abstract string CastAbility();
    }
}
