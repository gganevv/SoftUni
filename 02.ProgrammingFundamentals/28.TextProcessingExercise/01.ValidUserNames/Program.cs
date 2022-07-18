using System;

namespace _01.ValidUserNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine().Split(", ");

            foreach (var name in userNames)
            {
                if (name.Length >= 3 && name.Length <= 16)
                {
                    bool validName = true;
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (!(char.IsLetterOrDigit(name[i]) ||name[i] == '-' || name[i] == '_'))
                        {
                            validName = false;
                            break;
                        }
                    }

                    if (validName)
                    {
                        Console.WriteLine(name);
                    }
                }
            }
        }
    }
}
