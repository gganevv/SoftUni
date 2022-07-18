using System;

namespace _02.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            MultiplyChars(words[0], words[1]);
        }

        private static void MultiplyChars(string arr1, string arr2)
        {
            int sum = 0;
            char[] biggerArr;
            char[] smallerArr;
            if (arr1.Length > arr2.Length)
            {
                biggerArr = arr1.ToCharArray();
                smallerArr = arr2.ToCharArray();
            }
            else
            {
                biggerArr = arr2.ToCharArray();
                smallerArr = arr1.ToCharArray();
            }

            for (int i = 0; i < smallerArr.Length; i++)
            {
                sum += biggerArr[i] * smallerArr[i];
            }

            for (int i = smallerArr.Length; i < biggerArr.Length; i++)
            {
                sum += biggerArr[i];
            }

            Console.WriteLine(sum);
        }
    }
}
