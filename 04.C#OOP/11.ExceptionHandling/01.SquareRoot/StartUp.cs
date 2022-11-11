namespace _01.SquareRoot
{
    using System;
    public class StartUp
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            try
            {
                if (num < 0)
                {
                    throw new InvalidOperationException("Invalid number.");
                }
                Console.WriteLine(Math.Sqrt(num));
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
