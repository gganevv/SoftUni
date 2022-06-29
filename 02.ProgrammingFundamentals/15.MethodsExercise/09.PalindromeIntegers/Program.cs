using System;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                bool palindrome = CheckPalindrome(command);
                Console.WriteLine(palindrome.ToString().ToLower());

                command = Console.ReadLine();
            }
        }

        private static bool CheckPalindrome(string num)
        {
            if (num.Length < 2)
            {
                return true;
            }

            if (num[0] == num[num.Length - 1])
            {
                return true;
            }

            return false;
        }
    }
}
