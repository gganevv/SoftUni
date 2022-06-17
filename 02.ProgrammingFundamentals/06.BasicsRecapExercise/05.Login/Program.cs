using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            //On the first line, you will be given a username and your task is to try
            //to log in the user. The user's password is the username reversed. On the
            //next lines, you will receive passwords:
            //If the password is incorrect, print "Incorrect password. Try again.".
            //If the password is correct, print "User {username} logged in." and stop
            //the program.
            //Keep in mind that if the password is still incorrect on the fourth
            //attempt, you should print: "User {username} blocked!".
            //Then the program stops.

            string user = Console.ReadLine();
            string password = "";
            int wrongAttempts = 0;

            for (int i = user.Length - 1; i >= 0; i--)
            {
                password += user[i];
            }

            string login = Console.ReadLine();
            while (login != password)
            {
                wrongAttempts++;
                if (wrongAttempts == 4)
                {
                    Console.WriteLine($"User {user} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
                login = Console.ReadLine();
            }

            Console.WriteLine($"User {user} logged in.");
        }
    }
}
