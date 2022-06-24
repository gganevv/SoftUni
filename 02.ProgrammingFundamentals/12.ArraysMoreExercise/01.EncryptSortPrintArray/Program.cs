using System;

namespace _01.EncryptSortPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNames = int.Parse(Console.ReadLine());
            string[] names = new string[numberOfNames];
            int[] nameCodes = new int[numberOfNames];

            for (int i = 0; i < numberOfNames; i++)
            {
                names[i] = Console.ReadLine();
            }

            for (int i = 0; i < names.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < names[i].Length; j++)
                {
                    if (names[i][j] == 'a' || names[i][j] == 'e' || names[i][j] == 'i' || names[i][j] == 'o' || names[i][j] == 'u' || names[i][j] == 'A' || names[i][j] == 'E' || names[i][j] == 'I' || names[i][j] == 'O' || names[i][j] == 'U')
                    {
                        sum += (int)names[i][j] * names[i].Length;
                    }
                    else
                    {
                        sum += (int)names[i][j] / names[i].Length;
                    }
                }
                nameCodes[i] = sum;
            }

            Array.Sort(nameCodes);

            foreach (var name in nameCodes)
            {
                Console.WriteLine(name);
            }
        }
    }
}
