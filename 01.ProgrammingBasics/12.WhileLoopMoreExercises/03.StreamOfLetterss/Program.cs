using System;

namespace _03.StreamOfLetterss
{
    class Program
    {
        static void Main(string[] args)
        {
            bool c = false;
            bool o = false;
            bool n = false;
            string command = Console.ReadLine();
            string word = string.Empty;
            while (command != "End")
            {
                char com = char.Parse(command);
                if (command == "c" && c == false)
                {
                    c = true;
                }
                else if (command == "o" && o == false)
                {
                    o = true;
                }
                else if (command == "n" && n == false)
                {
                    n = true;
                }
                else if ((com > 64 && com < 91) || (com > 96 && com < 123))
                {
                    word += command;
                }

                if (c && o && n)
                {
                    Console.Write(word + " ");
                    c = false;
                    o = false;
                    n = false;
                    word = string.Empty;
                }
                command = Console.ReadLine();
            }
        }
    }
}
