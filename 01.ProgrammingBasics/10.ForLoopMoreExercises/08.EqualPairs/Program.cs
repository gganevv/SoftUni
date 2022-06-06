using System;

namespace _08.EqualPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            int pairs = int.Parse(Console.ReadLine());
            int firstN = int.Parse(Console.ReadLine());
            int secondN = int.Parse(Console.ReadLine());
            int pastSum = firstN + secondN;
            bool same = true;
            int diff = 0;

            for (int i = 1; i < pairs; i++)
            {
                int n1 = int.Parse(Console.ReadLine());
                int n2 = int.Parse(Console.ReadLine());
                int sum = n1 + n2;
                if (sum != pastSum)
                {
                    same = false;
                    if (Math.Abs(sum - pastSum) > diff)
                    {
                        diff = Math.Abs(sum - pastSum);
                    }
                }
                pastSum = sum;
            }
            if (same)
            {
                Console.WriteLine($"Yes, value={pastSum}");
            }
            else
            {
                Console.WriteLine($"No, maxdiff={diff}");
            }
        }
    }
}
