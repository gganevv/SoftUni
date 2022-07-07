using System;

namespace _01.BonusScoringProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            int numberOfLectures = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());
            double maxBonus = 0;
            int bestAttendances = 0;

            for (int i = 0; i < numberOfStudents; i++)
            {
                int studentAttendances = int.Parse(Console.ReadLine());
                double studentBonus = 1.0 * studentAttendances / numberOfLectures * (5 + bonus);
                if (studentBonus > maxBonus)
                {
                    maxBonus = studentBonus;
                    bestAttendances = studentAttendances;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {bestAttendances} lectures.");
        }
    }
}
