using System;
using System.Collections.Generic;
using System.Linq;

class FilterByAge
{
    static void Main()
    {
        List<Person> people = ReadPeople();

        string condition = Console.ReadLine();
        int ageCondition = int.Parse(Console.ReadLine());
        string format = Console.ReadLine();

        Func<Person, bool> filter = CreateFilter(condition, ageCondition);
        List<Person> filteredPeople = people.Where(filter).ToList();

        Action<Person> printer = CreatePrinter(format);
        PrintPeople(filteredPeople, printer);
    }

    static List<Person> ReadPeople()
    {
        List<Person> people = new List<Person>();
        int personsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < personsCount; i++)
        {
            string[] personArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string personName = personArgs[0];
            int personAge = int.Parse(personArgs[1]);
            people.Add(new Person(personName, personAge));
        }
        return people;
    }

    public static Func<Person, bool> CreateFilter(string condition, int age)
    {
        if (condition == "younger")
        {
            return x => x.Age < age;
        }
        else
        {
            return x => x.Age >= age;
        }
    }

    static Action<Person> CreatePrinter(string format)
    {
        switch (format)
        {
            case "name":
                return (Person p) => Console.WriteLine($"{p.Name}");
            case "age":
                return (Person p) => Console.WriteLine($"{p.Age}");
            case "name age":
                return (Person p) => Console.WriteLine($"{p.Name} - {p.Age}");
        }
        return null;
    }

    static void PrintPeople(List<Person> filteredPeople, Action<Person> printPerson)
    {
        foreach (var person in filteredPeople)
        {
            printPerson(person);
        }
    }
}
