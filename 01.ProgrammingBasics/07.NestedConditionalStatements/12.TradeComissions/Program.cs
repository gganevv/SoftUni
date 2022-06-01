using System;

namespace _12.TradeComissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string cityName = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double comission = 0;
            switch (cityName)
            {
                case "Sofia":
                    if (sales < 0)
                    {
                        Console.WriteLine("error");
                    }
                    else if (sales > 0 && sales <= 500)
                    {
                        comission = sales * 0.05;
                    }
                    else if (sales <= 1000)
                    {
                        comission = sales * 0.07;
                    }
                    else if (sales <= 10000)
                    {
                        comission = sales * 0.08;
                    }
                    else
                    {
                        comission = sales * 0.12;
                    }
                    break;
                case "Varna":
                    if (sales < 0)
                    {
                        Console.WriteLine("error");
                    }
                    else if (sales > 0 && sales <= 500)
                    {
                        comission = sales * 0.045;
                    }
                    else if (sales <= 1000)
                    {
                        comission = sales * 0.075;
                    }
                    else if (sales <= 10000)
                    {
                        comission = sales * 0.1;
                    }
                    else
                    {
                        comission = sales * 0.13;
                    }
                    break;
                case "Plovdiv":
                    if (sales < 0)
                    {
                        Console.WriteLine("error");
                    }
                    else if (sales > 0 && sales <= 500)
                    {
                        comission = sales * 0.055;
                    }
                    else if (sales <= 1000)
                    {
                        comission = sales * 0.08;
                    }
                    else if (sales <= 10000)
                    {
                        comission = sales * 0.12;
                    }
                    else
                    {
                        comission = sales * 0.145;
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
            if (comission > 0)
            {
                Console.WriteLine($"{comission:f2}");
            }
        }
    }
}
