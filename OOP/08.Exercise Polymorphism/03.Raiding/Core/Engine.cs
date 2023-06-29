using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly List<BaseHero> heroes;

        public Engine()
        {
            this.heroes = new List<BaseHero>();
        }

        public void Start()
        {
            BaseHero hero = null;
            int heroesNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < heroesNumber; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    hero = HeroFactory.CreateHero(name, type);
                    heroes.Add(hero);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                    continue;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = 0;

            foreach (var hero1 in heroes)
            {
                Console.WriteLine(hero1.CastAbility());
                heroesPower += hero1.Power;
            }

            Console.WriteLine(heroesPower>=bossPower ? "Victory!" : "Defeat...");
        }
    }
}
