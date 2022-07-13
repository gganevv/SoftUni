using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());
                if (!materials.ContainsKey(input))
                {
                    materials[input] = 0;
                }

                materials[input] += quantity;


                input = Console.ReadLine();
            }

            foreach (var m in materials)
            {
                Console.WriteLine($"{m.Key} -> {m.Value}");
            }
        }
    }
}
