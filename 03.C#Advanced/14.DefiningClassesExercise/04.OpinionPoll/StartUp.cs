using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int numberofPeople = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < numberofPeople; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                Person person = new Person(name, age);
                people.Add(person);
            }

            Console.WriteLine(String.Join("\n", people.Where(x => x.Age > 30).OrderBy(x => x.Name)));
        }
    }
}
