using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            //You will receive three lines from the console:
            //A count of people who are going on vacation.
            //Type of the group(Students, Business or Regular).
            //The day of the week which the group will stay on
            //(Friday, Saturday or Sunday).
            //Based on the given information calculate how much the group will pay for
            //the entire vacation.
            //The price for a single person is as follows:

            //          Friday  Saturday  Sunday
            //Students    8.45    9.80    10.46
            //Business    10.90   15.60   16
            //Regular     15      20      22.50

            //There are also discounts based on some conditions:
            //For Students – if the group is 30 or more people, you should reduce the
            //total price by 15 %.
            //For Business – if the group is 100 or more people, 10 of the people stay
            //for free.
            //For Regular – if the group is between 10 and 20  people(both inclusively),
            //reduce the total price by 5 %.
            //Note: You should reduce the prices in that EXACT order!
            //As an output print the final price which the group is going to pay in the
            //format: 
            //"Total price: {price}"
            //The price should be formatted to the second decimal point.

            int groupCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();

            double totalPrice = 0;

            if (groupType == "Students")
            {
                if (day == "Friday")
                {
                    totalPrice = groupCount * 8.45;
                }
                else if (day == "Saturday")
                {
                    totalPrice = groupCount * 9.8;
                }
                else if (day == "Sunday")
                {
                    totalPrice = groupCount * 10.46;
                }

                if (groupCount >= 30)
                {
                    totalPrice *= 0.85;
                }
            }
            else if (groupType == "Business")
            {
                if (groupCount >= 100)
                {
                    groupCount -= 10;
                }

                if (day == "Friday")
                {
                    totalPrice = groupCount * 10.9;
                }
                else if (day == "Saturday")
                {
                    totalPrice = groupCount * 15.6;
                }
                else if (day == "Sunday")
                {
                    totalPrice = groupCount * 16;
                }
            }
            else if (groupType == "Regular")
            {
                if (day == "Friday")
                {
                    totalPrice = groupCount * 15;
                }
                else if (day == "Saturday")
                {
                    totalPrice = groupCount * 20;
                }
                else if (day == "Sunday")
                {
                    totalPrice = groupCount * 22.5;
                }

                if (groupCount >= 10 && groupCount <= 20)
                {
                    totalPrice *= 0.95;
                }
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
