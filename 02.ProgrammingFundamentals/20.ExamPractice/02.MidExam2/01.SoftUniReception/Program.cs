using System;

namespace _01.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeStudents = int.Parse(Console.ReadLine());
            int secondEmployeeStudents = int.Parse(Console.ReadLine());
            int thirdEmployeeStudents = int.Parse(Console.ReadLine());
            int totalStudentsPerHour = firstEmployeeStudents + secondEmployeeStudents + thirdEmployeeStudents;

            int studentsCount = int.Parse(Console.ReadLine());
            int timeCounter = 0;

            while (studentsCount > 0)
            {
                timeCounter++;
                studentsCount -= totalStudentsPerHour;
                if (timeCounter % 4 == 0)
                {
                    timeCounter++;
                    continue;
                }
            }

            Console.WriteLine($"Time needed: {timeCounter}h.");
        }
    }
}
