using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DragonArmy
{
    class Program
    {
        private const int DRAGON_DEFAULT_DAMAGE = 45;
        private const int DRAGON_DEFAULT_HEALTH = 250;
        private const int DRAGON_DEFAULT_ARMOR = 10;

        static void Main(string[] args)
        {
            List<Dragon> dragons = new List<Dragon>();
            List<string> dragonTypes = new List<string>();

            int numberOfDragons = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string dragonType = inputArgs[0];
                string dragonName = inputArgs[1];
                int dragonDamage = 0;
                int drahonHealth = 0;
                int dragonArmor = 0;
                bool damageNotNull = int.TryParse(inputArgs[2], out dragonDamage);
                bool healthNotNull = int.TryParse(inputArgs[3], out drahonHealth);
                bool armorNotNull = int.TryParse(inputArgs[4], out dragonArmor);
                if (!dragonTypes.Contains(dragonType))
                {
                    dragonTypes.Add(dragonType);
                }

                if (!dragons.Any(x => x.Name == dragonName && x.Type == dragonType))
                {
                    Dragon dragon = new Dragon(dragonType, dragonName, damageNotNull ? dragonDamage : DRAGON_DEFAULT_DAMAGE, healthNotNull ? drahonHealth : DRAGON_DEFAULT_HEALTH, armorNotNull ? dragonArmor : DRAGON_DEFAULT_ARMOR);
                    dragons.Add(dragon);
                }
                else
                {
                    Dragon dragon = dragons.First(x => x.Name == dragonName && x.Type == dragonType);
                    dragon.Damage = damageNotNull ? dragonDamage : DRAGON_DEFAULT_DAMAGE;
                    dragon.Health = healthNotNull ? drahonHealth : DRAGON_DEFAULT_HEALTH;
                    dragon.Armor = armorNotNull ? dragonArmor : DRAGON_DEFAULT_ARMOR;
                }

            }

            foreach (var type in dragonTypes)
            {
                double avgDamage = 0;
                double avgHealth = 0;
                double avgArmor = 0;
                int dragonCounter = 0;

                foreach (var dragon in dragons)
                {
                    if (dragon.Type == type)
                    {
                        avgDamage += dragon.Damage;
                        avgHealth += dragon.Health;
                        avgArmor += dragon.Armor;
                        dragonCounter++;
                    }
                }

                Console.WriteLine($"{type}::({avgDamage / dragonCounter:f2}/{avgHealth / dragonCounter:f2}/{avgArmor / dragonCounter:f2})");

                foreach (var dragon in dragons.OrderBy(x => x.Name))
                {
                    if (dragon.Type == type)
                    {
                        Console.WriteLine(dragon);
                    }
                }
            }
        }
    }
}
