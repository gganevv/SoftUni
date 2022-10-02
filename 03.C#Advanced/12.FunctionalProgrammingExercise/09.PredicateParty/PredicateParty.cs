using System;
using System.Collections.Generic;
using System.Linq;

class PredicateParty
{
    static void Main()
    {
        List<string> people = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "StartsWith":
                    return s => s.StartsWith(value);
                case "EndsWith":
                    return s => s.EndsWith(value);
                case "Length":
                    return s => s.Length == int.Parse(value);
                default:
                    return default(Predicate<string>);
            }
        }

        string input = Console.ReadLine();
        while (input != "Party!")
        {
            string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = inputArgs[0];
            string filter = inputArgs[1];
            string value = inputArgs[2];

            if (command == "Remove")
            {
                people.RemoveAll(GetPredicate(filter, value));
            }
            else
            {
                List<string> peopleToMultiply = people.FindAll(GetPredicate(filter, value));

                int index = people.FindIndex(GetPredicate(filter, value));

                if (index >= 0)
                {
                    people.InsertRange(index, peopleToMultiply);
                }
            }

            input = Console.ReadLine();
        }

        if (people.Any())
        {
            Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }
    }
}