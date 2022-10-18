using System;
using System.Collections.Generic;

namespace _06.EqualityLogic
{
    public class StartUp
    {
        static void Main()
        {
            SortedSet<Person> peopleSS = new SortedSet<Person>();
            HashSet<Person> peopleHS = new HashSet<Person>();

            int numberOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(personArgs[0], int.Parse(personArgs[1]));

                peopleSS.Add(person);
                peopleHS.Add(person);
            }

            Console.WriteLine(peopleSS.Count);
            Console.WriteLine(peopleHS.Count);
        }
    }
}
