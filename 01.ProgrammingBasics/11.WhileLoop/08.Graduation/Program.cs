using System;

namespace _08.Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int clas = 1;
            double totalGrade = 0;
            int badGradeCounter = 0;

            while (clas <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4)
                {
                    totalGrade += grade;
                    clas++;
                }
                else
                {
                    badGradeCounter++;
                    if (badGradeCounter == 2)
                    {
                        break;
                    }
                }
                
            }
            if (badGradeCounter < 2)
            {
                Console.WriteLine($"{name} graduated. Average grade: {totalGrade / 12:f2}");
            }
            else
            {
                Console.WriteLine($"{name} has been excluded at {clas} grade");
            }
        }
    }
}
