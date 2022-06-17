using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double lightSaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            int freeBelts = countOfStudents / 6; 
            double lightSabersTotalPrice = lightSaberPrice * Math.Ceiling(countOfStudents * 1.1);
            double robesTotalPrice = robePrice * countOfStudents;
            double beltsTotalPrice = beltPrice * (countOfStudents - freeBelts);

            double totalPrice = lightSabersTotalPrice + robesTotalPrice + beltsTotalPrice;

            if (budget >= totalPrice)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalPrice - budget:f2}lv more.");
            }
        }
    }
}
