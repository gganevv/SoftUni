using System;

namespace _03.QuickDraw
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quick Draw");
            Console.WriteLine();
            Console.WriteLine("Face your opponent and wait for the signal.");
            Console.WriteLine("Once the signal is given, shoot your opponent by pressong [space]");
            Console.WriteLine("before they shoot you. It's all about your reaction time.");
            Console.WriteLine("Choose Your Opponent:");
            Console.WriteLine();
            Console.WriteLine("[1] Easy....1000 milliseconds");
            Console.WriteLine("[2] Medium...500 milliseconds");
            Console.WriteLine("[3] Hard.....250 milliseconds");
            Console.WriteLine("[4] Harder...125 milliseconds");

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
