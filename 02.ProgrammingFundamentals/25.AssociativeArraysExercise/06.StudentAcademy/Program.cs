using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            int numberOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStudents; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(student))
                {
                    students.Add(student, new List<double>());
                }

                students[student].Add(grade);
            }
            students = students.Where(x => x.Value.Average() >= 4.5).ToDictionary(x => x.Key, y => y.Value);

            foreach (var s in students)
            {
                Console.WriteLine($"{s.Key} -> {s.Value.Average():f2}");
            }
        }
    }
}
