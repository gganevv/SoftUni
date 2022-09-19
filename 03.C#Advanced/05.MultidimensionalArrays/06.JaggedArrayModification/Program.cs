using System;
using System.Linq;

namespace _06.JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split();
                string command = inputArgs[0];
                int row = int.Parse(inputArgs[1]);
                int col = int.Parse(inputArgs[2]);
                int value = int.Parse(inputArgs[3]);
                bool valid = false;


                if (command == "Add")
                {
                    if (jaggedArray.Length > row && row >= 0)
                    {
                        if (jaggedArray[row].Length > col && col >= 0)
                        {
                            jaggedArray[row][col] += value;
                            valid = true;
                        }
                    }
                }
                else if (command == "Subtract")
                {
                    if (jaggedArray.Length > row && row >= 0)
                    {
                        if (jaggedArray[row].Length > col && col >= 0)
                        {
                            jaggedArray[row][col] -= value;
                            valid = true;
                        }
                    }
                }

                if (!valid)
                {
                    Console.WriteLine("Invalid coordinates");
                }

                input = Console.ReadLine();
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(String.Join(" ", jaggedArray[i]));
            }
        }
    }
}
