using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        const int MAX_HP = 100;
        const int MAX_MP = 200;
        static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] heroArgs = Console.ReadLine().Split();
                string heroName = heroArgs[0];
                int heroHitPoints = int.Parse(heroArgs[1]);
                int heroManaPoints = int.Parse(heroArgs[2]);
                heroes.Add(new Hero(heroName, heroHitPoints, heroManaPoints));
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputArgs = input.Split(" - ");
                string heroName = inputArgs[1];
                int amount = int.Parse(inputArgs[2]);
                switch (inputArgs[0])
                {
                    case "CastSpell":
                        CastSpell(heroes, heroName, amount, inputArgs[3]);
                        break;
                    case "TakeDamage":
                        TakeDamage(heroes, heroName, amount, inputArgs[3]);
                        break;
                    case "Recharge":
                        Recharge(heroes, heroName, amount);
                        break;
                    case "Heal":
                        Heal(heroes, heroName, amount);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            heroes.ForEach(Console.WriteLine);
        }

        private static void CastSpell(List<Hero> heroes, string heroName, int amount, string spellName)
        {
            var currentHero = heroes.First(x => x.Name == heroName);
            if (currentHero.ManaPoints >= amount)
            {
                currentHero.ManaPoints -= amount;
                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {currentHero.ManaPoints} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }
        }

        private static void TakeDamage(List<Hero> heroes, string heroName, int amount, string attacker)
        {
            var currentHero = heroes.First(x => x.Name == heroName);
            currentHero.HitPoints -= amount;
            if (currentHero.HitPoints > 0)
            {
                Console.WriteLine($"{heroName} was hit for {amount} HP by {attacker} and now has {currentHero.HitPoints} HP left!");
            }
            else
            {
                heroes.Remove(currentHero);
                Console.WriteLine($"{heroName} has been killed by {attacker}!");
            }
        }

        private static void Recharge(List<Hero> heroes, string heroName, int amount)
        {
            var currentHero = heroes.First(x => x.Name == heroName);
            int startingMP = currentHero.ManaPoints;
            currentHero.ManaPoints += amount;
            if (currentHero.ManaPoints > MAX_MP)
            {
                currentHero.ManaPoints = MAX_MP;
            }
            Console.WriteLine($"{heroName} recharged for {currentHero.ManaPoints - startingMP} MP!");
        }

        private static void Heal(List<Hero> heroes, string heroName, int amount)
        {
            var currentHero = heroes.First(x => x.Name == heroName);
            int startingHP = currentHero.HitPoints;
            currentHero.HitPoints += amount;
            if (currentHero.HitPoints > MAX_HP)
            {
                currentHero.HitPoints = MAX_HP;
            }
            Console.WriteLine($"{heroName} healed for {currentHero.HitPoints - startingHP} HP!");

        }
    }
}
