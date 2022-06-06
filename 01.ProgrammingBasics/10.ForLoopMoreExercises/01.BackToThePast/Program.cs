using System;

namespace _01.BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int age = 18;
            double moneySpent = 0;

            for (int i = 1800; i <= year; i++)
            {
                if (i % 2 == 0)
                {
                    moneySpent += 12000;
                }
                else
                {
                    moneySpent += 12000 + (50 * age);
                }
                age++;
            }

            double diff = Math.Abs(moneySpent - money);
            if (money >= moneySpent)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {diff:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {diff:f2} dollars to survive.");
            }
        }
    }
}
