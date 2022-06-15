using System;

namespace _04.Workout
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double runKms = double.Parse(Console.ReadLine());
            double totalKms = runKms;
            double increase = 0;

            for (int i = 0; i < days; i++)
            {
                increase = 1 + (double.Parse(Console.ReadLine()) / 100);
                runKms *= increase;
                totalKms += runKms;
            }
            double diff = Math.Ceiling(Math.Abs(1000 - totalKms));
            if (totalKms >= 1000)
            {
                Console.WriteLine($"You've done a great job running {diff} more kilometers!");
            }
            else
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {diff} more kilometers");
            }
        }
    }
}
