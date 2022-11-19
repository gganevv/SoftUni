namespace CommandPattern.Core
{
    using Core.Contracts;
    using System;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string command;
            while (true)
            {
                command = Console.ReadLine();
                string result = commandInterpreter.Read(command);
                Console.WriteLine(result);
            }
        }
    }
}
