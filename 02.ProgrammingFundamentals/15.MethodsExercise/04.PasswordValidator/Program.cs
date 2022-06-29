using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool valid = true;

            if (!HasLength(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                valid = false;
            }

            if (!HaveOnlyLettersAndDigits(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                valid = false;
            }

            if (!HaveAtLeastTwoDigits(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
                valid = false;
            }

            if (valid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool HaveAtLeastTwoDigits(string password)
        {
            int digitsCount = 0;
            foreach (char s in password)
            {
                if (char.IsDigit(s))
                {
                    digitsCount++;
                }
            }

            return digitsCount >= 2;
        }

        private static bool HaveOnlyLettersAndDigits(string password)
        {
            foreach (var s in password)
            {
                if (!char.IsLetterOrDigit(s))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool HasLength(string password)
        {
            return password.Length >= 6 && password.Length <= 10;
        }
    }
}