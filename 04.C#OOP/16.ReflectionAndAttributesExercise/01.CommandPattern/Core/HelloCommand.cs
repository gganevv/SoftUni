namespace CommandPattern.Core
{
    using System;

    using Core.Contracts;
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
            => $"Hello, {args[0]}";
    }
}