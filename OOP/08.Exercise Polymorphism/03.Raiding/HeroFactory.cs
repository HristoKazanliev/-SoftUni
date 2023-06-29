using _03.Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class HeroFactory
    {
        public static BaseHero CreateHero(string heroName, string heroType)
        {
            if (heroType == "Druid")
            {
                return new Druid(heroName);
            }
            else if (heroType == "Paladin")
            {
                return new Paladin(heroName);
            }
            else if (heroType == "Rogue")
            {
                return new Rogue(heroName);
            }
            else if (heroType == "Warrior")
            {
                return new Warrior(heroName);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }
        }
        
    }
}
