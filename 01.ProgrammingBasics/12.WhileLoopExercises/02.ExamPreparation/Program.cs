using System;

namespace _02.ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxBadGrades = int.Parse(Console.ReadLine());
            int badGrades = 0;
            string problemName = string.Empty;
            double totalGrade = 0;
            double gradeCounter = 0;
            string lastProblem = string.Empty;
            while (problemName != "Enough")
            {
                problemName = Console.ReadLine();
                if (problemName == "Enough")
                {
                    Console.WriteLine($"Average score: {totalGrade / gradeCounter:f2}");
                    Console.WriteLine($"Number of problems: {gradeCounter}");
                    Console.WriteLine($"Last problem: {lastProblem}");
                    break;
                }
                else
                {
                    int grade = int.Parse(Console.ReadLine());
                    totalGrade += grade;
                    lastProblem = problemName;
                    if (grade <= 4)
                    {
                        badGrades++;
                    }
                    if (badGrades == maxBadGrades)
                    {
                        Console.WriteLine($"You need a break, {maxBadGrades} poor grades.");
                        break;
                    }
                }
                gradeCounter++;
            }
        }
    }
}
