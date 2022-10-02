using System;
using System.Collections.Generic;
using System.Linq;

class PartyReservationFilterModule
{
    static void Main(string[] args)
    {
        List<string> people = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToList();
        Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Starts with":
                    return s => s.StartsWith(value);
                case "Ends with":
                    return s => s.EndsWith(value);
                case "Length":
                    return s => s.Length == int.Parse(value);
                case "Contains":
                    return s => s.Contains(value);
                default:
                    return default(Predicate<string>);
            }
        }

        string input = Console.ReadLine();
        while (input != "Print")
        {
            string[] inputArgs = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

            string command = inputArgs[0];
            string filter = inputArgs[1];
            string value = inputArgs[2];

            if (command == "Add filter")
            {
                filters.Add(filter + value, GetPredicate(filter, value));
            }
            else
            {
                filters.Remove(filter + value);
            }

            input = Console.ReadLine();
        }

        foreach (var filter in filters)
        {
            people.RemoveAll(filter.Value);
        }
        Console.WriteLine(string.Join(" ", people));
    }
}