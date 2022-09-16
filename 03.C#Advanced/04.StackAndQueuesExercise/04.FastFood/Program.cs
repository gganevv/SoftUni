using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodAvaible = int.Parse(Console.ReadLine());
            int[] ordersArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> orders = new Queue<int>(ordersArr);
            Console.WriteLine(orders.Max());
            bool ordersCoplete = true;
            while (orders.Count > 0)
            {
                int currentOrder = orders.Peek();
                if (foodAvaible >= currentOrder)
                {
                    orders.Dequeue();
                    foodAvaible -= currentOrder;
                }
                else
                {
                    ordersCoplete = false;
                    break;
                }
            }

            if (ordersCoplete)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {String.Join(" ", orders)}");
            }
        }
    }
}