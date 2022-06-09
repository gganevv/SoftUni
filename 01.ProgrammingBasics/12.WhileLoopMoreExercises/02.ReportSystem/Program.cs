using System;

namespace _02.ReportSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededMoney = int.Parse(Console.ReadLine());
            int collectedMoney = 0;
            string command = Console.ReadLine();
            int paimentN = 0;
            double cs = 0;
            double csTotal = 0;
            double cc = 0;
            double ccTotal = 0;
            while (command != "End")
            {
                paimentN++;
                int payment = int.Parse(command);
                if (paimentN % 2 != 0)
                {
                    if (payment > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        collectedMoney += payment;
                        cs++;
                        csTotal += payment;
                    }
                }
                else
                {
                    if (payment < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        collectedMoney += payment;
                        cc++;
                        ccTotal += payment;
                    }
                }
                if (collectedMoney >= neededMoney)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            if (collectedMoney < neededMoney)
            {
                Console.WriteLine($"Failed to collect required money for charity.");
            }
            else
            {
                Console.WriteLine($"Average CS: {csTotal/cs:f2}");
                Console.WriteLine($"Average CC: {ccTotal/cc:f2}");
            }
        }
    }
}
