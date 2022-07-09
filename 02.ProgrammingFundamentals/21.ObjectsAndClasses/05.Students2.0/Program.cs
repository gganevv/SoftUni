using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] inputArgs = input.Split();
                string firstName = inputArgs[0];
                string lastName = inputArgs[1];
                int age = int.Parse(inputArgs[2]);
                string homeTown = inputArgs[3];
                Student student = new Student(firstName, lastName, age, homeTown);

                if (students.FirstOrDefault(x => x.FullName == student.FullName) == null)
                {
                    students.Add(student);
                }
                else
                {
                    Student std = students.FirstOrDefault(x => x.FullName == student.FullName);
                    std.Age = age;
                    std.Town = homeTown;
                }


                input = Console.ReadLine();
            }

            string town = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.Town == town)
                {
                    Console.WriteLine($"{student.FullName} is {student.Age} years old.");
                }
            }
        }
    }
}
