using System;

namespace _07.TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            int grouoNumber = int.Parse(Console.ReadLine());
            double totalClimbers = 0;
            double m1 = 0;
            double m2 = 0;
            double m3 = 0;
            double m4 = 0;
            double m5 = 0;

            for (int i = 0; i < grouoNumber; i++)
            {
                int groupMembers = int.Parse(Console.ReadLine());
                totalClimbers += groupMembers;
                if (groupMembers <= 5)
                {
                    m1 += groupMembers;
                }
                else if (groupMembers <= 12)
                {
                    m2 += groupMembers;
                }
                else if (groupMembers <= 25)
                {
                    m3 += groupMembers;
                }
                else if (groupMembers <= 40)
                {
                    m4 += groupMembers;
                }
                else
                {
                    m5 += groupMembers;
                }
            }

            Console.WriteLine($"{m1 / totalClimbers * 100:f2}%");
            Console.WriteLine($"{m2 / totalClimbers * 100:f2}%");
            Console.WriteLine($"{m3 / totalClimbers * 100:f2}%");
            Console.WriteLine($"{m4 / totalClimbers * 100:f2}%");
            Console.WriteLine($"{m5 / totalClimbers * 100:f2}%");
        }
    }
}
