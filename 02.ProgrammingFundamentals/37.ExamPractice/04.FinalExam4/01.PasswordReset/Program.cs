using System;

namespace _01.PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Done")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];
                switch (command)
                {
                    case "TakeOdd":
                        password = TakeOdd(password);
                        break;
                    case "Cut":
                        password = Cut(int.Parse(inputArgs[1]), int.Parse(inputArgs[2]), password);
                        break;
                    case "Substitute":
                        password = Substitute(inputArgs[1], inputArgs[2], password);
                        break;
                    default:
                        break;
                }


                input = Console.ReadLine();
            }


            Console.WriteLine($"Your password is: {password}");
        }

        private static string TakeOdd(string password)
        {
            string newPassword = string.Empty;
            for (int i = 0; i < password.Length; i++)
            {
                if (i % 2 != 0)
                {
                newPassword += password[i];
                }
            }
            Console.WriteLine(newPassword);
            return newPassword;
        }

        private static string Cut(int index, int length, string password)
        {
            string newPassword = password.Substring(0, index);
            newPassword += password.Substring(index + length, password.Length - index - length) ;
            Console.WriteLine(newPassword);

            return newPassword;
        }

        private static string Substitute(string oldString, string newString, string password)
        {
            string newPassword = password.Replace(oldString, newString);
            if (password == newPassword)
            {
                Console.WriteLine("Nothing to replace!");
                return password;
            }
            Console.WriteLine(newPassword);

            return newPassword;
        }
    }
}
