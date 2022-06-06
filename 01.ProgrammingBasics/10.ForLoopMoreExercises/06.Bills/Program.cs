using System;

namespace _06.Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int mounths = int.Parse(Console.ReadLine());
            double totalBills = 0;
            double electricityTotal = 0;
            double otherTotal = 0;
            for (int i = 0; i < mounths; i++)
            {
                double electricityPrice = double.Parse(Console.ReadLine());
                electricityTotal += electricityPrice;
                double otherBills = (electricityPrice + 20 + 15) * 1.2;
                otherTotal += otherBills;
                totalBills += electricityPrice + 20 + 15 + otherBills;
            }
            Console.WriteLine($"Electricity: {electricityTotal:f2} lv");
            Console.WriteLine($"Water: {20*mounths:f2} lv");
            Console.WriteLine($"Internet: {15*mounths:f2} lv");
            Console.WriteLine($"Other: {otherTotal:f2} lv");
            Console.WriteLine($"Average: {totalBills / mounths:f2} lv");
        }
    }
}
