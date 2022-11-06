namespace BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using BirthdayCelebrations.Models;
    using BirthdayCelebrations.Models.Interfaces;

    public class StartUp
    {
        static void Main()
        {
            List<IBirthable> birthables = new List<IBirthable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split();
                string type = inputArgs[0];
                string name = inputArgs[1];
                switch (type)
                {
                    case "Citizen":
                        birthables.Add(new Citizen(name, int.Parse(inputArgs[2]), inputArgs[3], inputArgs[4]));
                        break;
                    case "Pet":
                        birthables.Add(new Pet(name, inputArgs[2]));
                        break;
                    default:
                        break;
                }
            }

            string year = Console.ReadLine();

            foreach (var b in birthables)
            {
                if (b.BirthDate.EndsWith(year))
                {
                    Console.WriteLine(b.BirthDate);
                }
            }
        }
    }
}
