namespace PlayCatch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int numberOfExceptions = 0;
            while (numberOfExceptions < 3)
            {
                string[] commandArgs = Console.ReadLine().Split();
                string command = commandArgs[0];
                string param = commandArgs[1];
                try
                {
                    switch (command)
                    {
                        case "Replace":
                            int newElement = int.Parse(commandArgs[2]);
                            nums[int.Parse(param)] = newElement;
                            break;
                        case "Show":
                            Console.WriteLine(nums[int.Parse(param)]);
                            break;
                        case "Print":
                            int startIndex = int.Parse(param);
                            int endIndex = int.Parse(commandArgs[2]);
                            List<int> newNums = new List<int>();
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                newNums.Add(nums[i]);
                            }
                            Console.WriteLine(String.Join(", ", newNums));
                            break;
                        default:
                            break;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    numberOfExceptions++;
                    Console.WriteLine("The index does not exist!");
                }
                catch(FormatException)
                {
                    numberOfExceptions++;
                    Console.WriteLine("The variable is not in the correct format!");
                }
            }

            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
