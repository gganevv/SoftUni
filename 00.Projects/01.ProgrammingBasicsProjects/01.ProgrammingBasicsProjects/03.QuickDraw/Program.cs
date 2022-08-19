using System;
using System.Diagnostics;

namespace _03.QuickDraw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string menu = @"Quick Draw
Face your opponent and wait for the signal.
Once the signal is given, shoot your opponent by pressong [space]
before they shoot you. It's all about your reaction time.

Choose Your Opponent:
[1] Easy....1000 milliseconds
[2] Medium...500 milliseconds
[3] Hard.....250 milliseconds
[4] Harder...125 milliseconds";

            string wait = @"                                                    
                        _O                          O_            
                       |/|_          wait          _|\|           
                       /\                            /\           
                      /  |                          |  \          
            ------------------------------------------------------";
            string fire = @"
                                           
                                   ********                       
                                   * FIRE *                       
                        _O         ********         O_            
                       |/|_                        _|\|           
                       /\          spacebar          /\           
                      /  |                          |  \          
            ------------------------------------------------------";
            string loseSlow = @"                                         
            
                                              > ╗__O          
                               Too Slow           / \         
                O/__/\         You Lose          /\           
                     \                          |  \          
            ------------------------------------------------------";

            string loseFast = @"                            
                                                              
                               Too Fast       > ╗__O          
                               You Missed         / \         
                O/__/\         You Lose          /\           
                     \                          |  \          
            ------------------------------------------------------";

            string win = @"
                                                              
                  O__╔ <                                      
                 / \                               \\         
                   /\          You Win          /\__\O        
                  /  |                          /             
            ------------------------------------------------------";

            while (true)
            {
                Console.Clear();
                Console.WriteLine(menu);
                TimeSpan timeSpan;

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        timeSpan = TimeSpan.FromMilliseconds(1000);
                        break;
                    case "2":
                        timeSpan = TimeSpan.FromMilliseconds(500);
                        break;
                    case "3":
                        timeSpan = TimeSpan.FromMilliseconds(250);
                        break;
                    case "4":
                        timeSpan = TimeSpan.FromMilliseconds(125);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        continue;
                }
                Console.Clear();

                TimeSpan signal = TimeSpan.FromMilliseconds(random.Next(5000, 10000));
                Console.WriteLine(wait);

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Restart();

                bool tooFast = false;

                while (stopwatch.Elapsed < signal && !tooFast)
                {
                    if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Spacebar)
                    {
                        tooFast = true;
                    }
                }

                Console.Clear();

                if (tooFast)
                {
                    Console.WriteLine(loseFast);
                }
                else
                {
                    Console.WriteLine(fire);
                    stopwatch.Restart();

                    bool tooSlow = true;

                    TimeSpan reactionTime = default;

                    while (stopwatch.Elapsed < timeSpan && tooSlow)
                    {
                        if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Spacebar)
                        {
                            tooSlow = false;
                            reactionTime = stopwatch.Elapsed;
                        }
                    }

                    Console.Clear();

                    if (tooSlow)
                    {
                        Console.WriteLine(loseSlow);
                    }
                    else
                    {
                        Console.WriteLine(win);
                        Console.WriteLine($"Reaction Time: {reactionTime.TotalMilliseconds} milliseconds");
                    }
                }

                Console.Write("Press [1] to Play Again or [2] to quit: ");
                string playOrQuit = Console.ReadLine();

                if (playOrQuit == "2")
                {
                    break;
                }
            }            
        }
    }
}
