using System;

namespace _09.FuelTank2
{
    class Program
    {
        static void Main(string[] args)
        {
            double gasolinePrice = 2.22;
            double dieselPrice = 2.33;
            double gasPrice = 0.93;

            string fuelType = Console.ReadLine();
            double fuelQty = double.Parse(Console.ReadLine());
            string discount = Console.ReadLine();
            bool card = true;
            if (discount == "No")
            {
                card = false;
            }

            double fuelPrice = fuelQty;

            switch (fuelType)
            {
                case "Gasoline":
                    if (card)
                    {
                        fuelPrice *= 2.04;
                    }
                    else
                    {
                        fuelPrice *= 2.22;
                    }
                    break;
                case "Diesel":
                    if (card)
                    {
                        fuelPrice *= 2.21;
                    }
                    else
                    {
                        fuelPrice *= 2.33;
                    }
                    break;
                case "Gas":
                    if (card)
                    {
                        fuelPrice *= 0.85;
                    }
                    else
                    {
                        fuelPrice *= 0.93;
                    }
                    break;
                default:
                    break;
            }

            if (fuelQty >= 20 && fuelQty <= 25)
            {
                fuelPrice *= 0.92;
            }
            else if (fuelQty > 25)
            {
                fuelPrice *= 0.9;
            }

            Console.WriteLine($"{fuelPrice:f2} lv.");
        }
    }
}
