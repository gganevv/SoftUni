using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Submission> submissions = new List<Submission>();

            string input = Console.ReadLine();
            while (input != "exam finished")
            {
                string[] inputArgs = input.Split('-');
                string studentName = inputArgs[0];
                string submissionName = inputArgs[1];
                if (submissionName == "banned")
                {
                    if (students.Any(x => x.Name == studentName))
                    {
                        students.Remove(students.FirstOrDefault(x => x.Name == studentName));
                    }
                }
                else
                {
                    int submissionPoints = int.Parse(inputArgs[2]);
                    if (!students.Any(x => x.Name == studentName))
                    {
                        students.Add(new Student(studentName, new Submission(submissionName, submissionPoints)));
                    }
                    else
                    {
                        Student student = students.FirstOrDefault(x => x.Name == studentName);
                        if (student.Submission.Points < submissionPoints)
                        {
                            student.Submission.Points = submissionPoints;
                        }
                    }

                    if (!submissions.Any(x => x.Name == submissionName))
                    {
                        submissions.Add(new Submission(submissionName));
                    }
                    else
                    {
                        submissions.FirstOrDefault(x => x.Name == submissionName).Count++;
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Results:");
            foreach (var student in students.OrderByDescending(x => x.Submission.Points).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{student.Name} | {student.Submission.Points}");
            }

            Console.WriteLine("Submissions:");
            foreach (var submission in submissions.OrderByDescending(x => x.Count).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{submission.Name} - {submission.Count}");
            }
        }
    }
}
