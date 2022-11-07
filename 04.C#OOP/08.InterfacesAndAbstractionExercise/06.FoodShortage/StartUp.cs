namespace FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using _06.FoodShortage.Models;
    using FoodShortage.Models;
    using Models.Interfaces;
    public class StartUp
    {
        static void Main()
        {
            int numberOfPeple = int.Parse(Console.ReadLine());
            List<IBuyer> buyerList = new List<IBuyer>();

            for (int i = 0; i < numberOfPeple; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string buyerName = inputArgs[0];
                int buyerAge = int.Parse(inputArgs[1]);

                if (inputArgs.Length == 3)
                {
                    buyerList.Add(new Rebel(buyerName, buyerAge, inputArgs[2]));
                }
                else if (inputArgs.Length == 4)
                {
                    buyerList.Add(new Citizen(buyerName, buyerAge, inputArgs[2], inputArgs[3]));
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                IBuyer buyer = buyerList.FirstOrDefault(x => x.Name == command);
                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            int sum = 0;
            buyerList.ForEach(x=> sum += x.Food);
            Console.WriteLine(sum);
        }
    }
}
