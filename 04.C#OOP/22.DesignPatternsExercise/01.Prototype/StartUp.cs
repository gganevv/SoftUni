namespace _01.Prototype
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            sandwichMenu["BLT"] = new Sandwitch("Wheat", "Bacon", "", "Lattuce, Tomato");
            sandwichMenu["PB&J"] = new Sandwitch("White", "", "", "PeanutButter, Jelly");
            sandwichMenu["Turkey"] = new Sandwitch("Rye", "Turkey", "Swiss", "Lattuce, Onion, Tomato");

            Sandwitch sandwitch1 = sandwichMenu["BLT"].Clone() as Sandwitch;
            Sandwitch sandwitch2 = sandwichMenu["PB&J"].Clone() as Sandwitch;
            Sandwitch sandwitch3 = sandwichMenu["Turkey"].Clone() as Sandwitch;
        }
    }
}
