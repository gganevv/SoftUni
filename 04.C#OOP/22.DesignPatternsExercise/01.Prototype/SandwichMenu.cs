namespace _01.Prototype
{
    using System.Collections.Generic;
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> sandwiches;

        public SandwichMenu()
        {
            sandwiches = new Dictionary<string, SandwichPrototype>();
        }

        public SandwichPrototype this[string name]
        {
            get { return sandwiches[name]; }
            set { sandwiches.Add(name, value); }
        }
    }
}
