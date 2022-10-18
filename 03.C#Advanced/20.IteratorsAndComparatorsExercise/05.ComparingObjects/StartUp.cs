using System;
using System.Collections.Generic;

namespace _05.ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] personArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);
                string town = personArgs[2];

                Person person = new Person(name, age, town);
                people.Add(person);

                input = Console.ReadLine();
            }

            int wantedPersonNumber = int.Parse(Console.ReadLine());
            Person wantedPerson = people[wantedPersonNumber - 1];

            int matches = 0;
            foreach (var person in people)
            {
                if (person.CompareTo(wantedPerson) == 0)
                {
                    matches++;
                }
            }

            if (matches < 2)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
            }
        }
    }
}
