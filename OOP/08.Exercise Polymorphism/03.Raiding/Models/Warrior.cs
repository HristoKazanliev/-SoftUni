using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
        }

        public override int Power => 100;

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
