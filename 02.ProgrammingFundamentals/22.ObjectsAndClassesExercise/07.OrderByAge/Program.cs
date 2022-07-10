using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split();
                string name = inputArgs[0];
                string id = inputArgs[1];
                int age = int.Parse(inputArgs[2]);
                Person currentPerson = new Person(name, id, age);
                if (people.Any(x => x.ID == id))
                {
                    Person person = people.First(x => x.ID == id);
                    person.Name = name;
                    person.Age = age;
                }
                else
                {
                people.Add(currentPerson);

                }

                input = Console.ReadLine();
            }

            people = people.OrderBy(x => x.Age).ToList();
            people.ForEach(x => Console.WriteLine(x));
        }
    }
}
