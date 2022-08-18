using System;

namespace _03.QuickDraw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quick Draw");
            Console.WriteLine();
            Console.WriteLine(@"Face your opponent and wait for the signal.
Once the signal is given, shoot your opponent by pressong [space]
before they shoot you. It's all about your reaction time.");
            Console.WriteLine("Choose Your Opponent:");
            Console.WriteLine();
            Console.WriteLine(@"[1] Easy....1000 milliseconds
[2] Medium...500 milliseconds
[3] Hard.....250 milliseconds
[4] Harder...125 milliseconds");

            int difficultity = int.Parse(Console.ReadLine());
            Console.Clear();

            string wait = @"                                                    
                        _O                          O_            
                       |/|_          wait          _|\|           
                       /\                            /\           
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


        }
    }
}
