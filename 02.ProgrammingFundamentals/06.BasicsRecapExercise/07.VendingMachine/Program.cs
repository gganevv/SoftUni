using System;

namespace _07.VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that accumulates coins. Until the "Start" command is given,
            //you will receive coins, and only the valid ones should be accumulated.
            //Valid coins are:
            //0.1, 0.2, 0.5, 1 and 2
            //If an invalid coin is inserted, print "Cannot accept {money}" and continue
            //to the next line.
            //On the next lines, until the "End" command is given, you will start
            //receiving products, which a customer wants to buy. The vending machine has
            //only:
            //"Nuts" with a price of 2.0
            //"Water" with a price of 0.7
            //"Crisps" with a price of 1.5
            //"Soda" with a price of 0.8
            //"Coke" with a price of 1.0
            //If the customer tries to purchase a not existing product, print
            //"Invalid product".
            //When a customer has enough money to buy the selected product, print
            //"Purchased {product name}", otherwise print "Sorry, not enough money" and
            //continue to the next line.
            //When the "End" command is given print the reminding balance, formatted to
            //the second decimal point: "Change: {money left}".

            double totalMoney = 0;

            string coin = Console.ReadLine();
            while (coin != "Start")
            {
                double currentCoin = double.Parse(coin);
                if (currentCoin == 0.1 || currentCoin == 0.2 || currentCoin == 0.5 || currentCoin == 1 || currentCoin == 2)
                {
                    totalMoney += currentCoin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {currentCoin}");
                }

                coin = Console.ReadLine();
            }

            string product = Console.ReadLine();
            while (product != "End")
            {
                double productPrice = 0;
                switch (product)
                {
                    case "Nuts":
                        productPrice = 2;
                        break;
                    case "Water":
                        productPrice = 0.7;
                        break;
                    case "Crisps":
                        productPrice = 1.5;
                        break;
                    case "Soda":
                        productPrice = 0.8;
                        break;
                    case "Coke":
                        productPrice = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        product = Console.ReadLine();
                        continue;
                }
                if (productPrice <= totalMoney)
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                    totalMoney -= productPrice;
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {totalMoney:f2}");
        }
    }
}
