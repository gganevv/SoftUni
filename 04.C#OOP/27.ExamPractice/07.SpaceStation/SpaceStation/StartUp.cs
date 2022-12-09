namespace SpaceStation
{
    using Core;
    using Core.Contracts;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}