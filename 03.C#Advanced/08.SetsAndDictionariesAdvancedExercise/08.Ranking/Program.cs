using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Contest> contestList = new List<Contest>();
            List<Student> studentList = new List<Student>();

            string contestInput = Console.ReadLine();
            while (contestInput != "end of contests")
            {
                CreateContests(contestInput, contestList);
                contestInput = Console.ReadLine();
            }

            string userInput = Console.ReadLine();
            while (userInput != "end of submissions")
            {
                string[] inputArgs = userInput.Split("=>");
                string contestName = inputArgs[0];
                string contestPassword = inputArgs[1];
                string studentName = inputArgs[2];
                int contestPoints = int.Parse(inputArgs[3]);
                if (ContestExist(contestList, contestName))
                {
                    Contest contest = contestList.FirstOrDefault(x => x.Name == contestName);
                    if (contest.Password == contestPassword)
                    {
                        if (StudentExist(studentList, studentName))
                        {
                            Student student = studentList.FirstOrDefault(x => x.Name == studentName);
                            if (!ContestExist(student.Contests, contestName))
                            {
                                student.Contests.Add(new Contest(contestName, contestPassword, contestPoints));
                            }
                            else if (student.Contests.FirstOrDefault(x => x.Name == contestName).Points < contestPoints)
                            {
                                student.Contests.FirstOrDefault(x => x.Name == contestName).Points = contestPoints;
                            }
                        }
                        else
                        {
                            Student student = new Student(studentName);
                            student.Contests.Add(new Contest(contestName, contestPassword, contestPoints));
                            studentList.Add(student);
                        }
                    }
                }

                userInput = Console.ReadLine();
            }

            PrintBestCandidate(studentList);

            Console.WriteLine("Ranking:");
            foreach (var student in studentList.OrderBy(x => x.Name))
            {
                Console.WriteLine(student);
            }
        }

        private static void PrintBestCandidate(List<Student> studentList)
        {
            string bestStudent = string.Empty;
            int bestPoints = 0;

            foreach (var student in studentList)
            {
                int currentPoints = 0;
                student.Contests.ForEach(x => currentPoints += x.Points);
                if (currentPoints > bestPoints)
                {
                    bestPoints = currentPoints;
                    bestStudent = student.Name;
                }
            }

            Console.WriteLine($"Best candidate is {bestStudent} with total {bestPoints} points.");
        }

        private static bool StudentExist(List<Student> studentList, string studentName) => studentList.Any(x => x.Name == studentName);

        private static bool ContestExist(List<Contest> contestList, string contestName) => contestList.Any(x => x.Name == contestName);

        private static void CreateContests(string contestInput, List<Contest> contestList)
        {
            string[] inputArgs = contestInput.Split(":");
            string contestName = inputArgs[0];
            string contestPassword = inputArgs[1];
            contestList.Add(new Contest(contestName, contestPassword));
        }
    }
}
