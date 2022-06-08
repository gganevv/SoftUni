using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double savedMoney = double.Parse(Console.ReadLine());
            int days = 0;
            int daysSpending = 0;
            while (true)
            {
                days++;
                string action = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());
                if (action == "spend")
                {
                    daysSpending++;
                    savedMoney -= money;
                    if (savedMoney < 0)
                    {
                        savedMoney = 0;
                    }
                    if (daysSpending == 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(days);
                        break;
                    }
                }
                else
                {
                    savedMoney += money;
                    if (savedMoney >= neededMoney)
                    {
                        Console.WriteLine($"You saved the money for {days} days.");
                        break;
                    }
                    daysSpending = 0;
                }
            }
        }
    }
}
