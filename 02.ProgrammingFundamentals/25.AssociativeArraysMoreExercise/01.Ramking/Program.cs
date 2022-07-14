using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Ramking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            List<Student> students = new List<Student>();
            Student bestStudent = new Student("");

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] inputArgs = input.Split(":");
                string contest = inputArgs[0];
                string password = inputArgs[1];
                contests.Add(contest, password);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] inputArgs = input.Split("=>");
                string contest = inputArgs[0];
                string password = inputArgs[1];
                string userName = inputArgs[2];
                int points = int.Parse(inputArgs[3]);

                bool validContest = contests.ContainsKey(contest);
                bool validPassword = false;

                if (validContest)
                {
                    validPassword = contests[contest] == password;
                }

                if (validContest && validPassword)
                {
                    AddStudent(students, userName);
                    Student student = students.First(x => x.Name == userName);
                    AddStudentContests(contest, points, student);
                }

                input = Console.ReadLine();
            }

            bestStudent = GetBestStudent(students, bestStudent);
            Console.WriteLine($"Best candidate is {bestStudent.Name} with total {bestStudent.GetTotalPoints()} points.");

            Console.WriteLine("Ranking: ");
            students = students.OrderBy(x => x.Name).ToList();
            students.ForEach(x => Console.WriteLine(x));
        }

        private static void AddStudentContests(string contest, int points, Student student)
        {
            if (!student.Contests.ContainsKey(contest))
            {
                student.Contests.Add(contest, points);
            }
            else if (student.Contests[contest] < points)
            {
                student.Contests[contest] = points;
            }
        }

        public static Student GetBestStudent(List<Student> students, Student bestStudent)
        {
            foreach (var student in students)
            {
                if (student.GetTotalPoints() > bestStudent.GetTotalPoints())
                {
                    bestStudent = student;
                }
            }

            return bestStudent;
        }

        public static void AddStudent(List<Student> students, string userName)
        {
            if (!students.Any(x => x.Name == userName))
            {
                Student newStudent = new Student(userName);
                students.Add(newStudent);
            }
        }
    }
}
