using System;
using System.Collections.Generic;

namespace _05.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputArgs = input.Split(" : ");
                string course = inputArgs[0];
                string student = inputArgs[1];

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }

                courses[course].Add(student);

                input = Console.ReadLine();
            }

            foreach (var c in courses)
            {
                Console.WriteLine($"{c.Key}: {c.Value.Count}");
                foreach (var s in c.Value)
                {
                    Console.WriteLine($"-- {s}");
                }
            }
        }
    }
}
