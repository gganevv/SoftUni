using System;

namespace _05.HairSalon
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int earnedMoney = 0;

            while (command != "closed")
            {
                if (command == "haircut")
                {
                    string type = Console.ReadLine();
                    if (type == "mens")
                    {
                        earnedMoney += 15;
                    }
                    else if (type == "ladies")
                    {
                        earnedMoney += 20;
                    }
                    else if (type == "kids")
                    {
                        earnedMoney += 10;
                    }
                }
                else if (command == "color")
                {
                    string type = Console.ReadLine();
                    if (type == "touch up")
                    {
                        earnedMoney += 20;
                    }
                    else if (type == "full color")
                    {
                        earnedMoney += 30;
                    }
                }
                if (earnedMoney >= target)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            if (earnedMoney >= target)
            {
                Console.WriteLine("You have reached your target for the day!");
            }
            else
            {
                Console.WriteLine($"Target not reached! You need {target - earnedMoney}lv. more.");
            }
            Console.WriteLine($"Earned money: {earnedMoney}lv.");
        }
    }
}
