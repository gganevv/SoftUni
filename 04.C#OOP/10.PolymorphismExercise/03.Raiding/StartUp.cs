﻿namespace Raiding
{
    using System;
    using System.Collections.Generic;
    using Raiding.Models;

    public class StartUp
    {
        static void Main()
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int numberOfHeroes = int.Parse(Console.ReadLine());
            while (heroes.Count != numberOfHeroes)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                switch (type)
                {
                    case "Druid":
                        heroes.Add(new Druid(name));
                        break;
                    case "Paladin":
                        heroes.Add(new Paladin(name));
                        break;
                    case "Rogue":
                        heroes.Add(new Rogue(name));
                        break;
                    case "Warrior":
                        heroes.Add(new Warrior(name));
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }
                
            heroes.ForEach(x => Console.WriteLine(x.CastAbility()));
            int bossPower = int.Parse(Console.ReadLine());
            int raidPower = 0;
            heroes.ForEach(x => raidPower += x.Power);

            Console.WriteLine(raidPower >= bossPower ? "Victory!" : "Defeat...");
        }
    }
}
