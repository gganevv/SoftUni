using System;

namespace _04.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            double s1 = 0;
            double s2 = 0;
            double s3 = 0;
            double s4 = 0;
            double totalgrade = 0;
            for (int i = 0; i < students; i++)
            {
                double studentGrade = double.Parse(Console.ReadLine());
                totalgrade += studentGrade;
                if (studentGrade >= 5)
                {
                    s1++;
                }
                else if (studentGrade >= 4)
                {
                    s2++;
                }
                else if (studentGrade >= 3)
                {
                    s3++;
                }
                else
                {
                    s4++;
                }
            }
            Console.WriteLine($"Top students: {s1 / students * 100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {s2 / students * 100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {s3 / students * 100:f2}%");
            Console.WriteLine($"Fail: {s4 / students * 100:f2}%");
            Console.WriteLine($"Average: {totalgrade / students:f2}");
        }
    }
}
