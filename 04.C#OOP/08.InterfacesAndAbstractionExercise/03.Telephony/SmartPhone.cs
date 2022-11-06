namespace Telephony
{
    using System;
    public class SmartPhone : ISmartPhone
    {
        public void Browse(string website)
        {
            Console.WriteLine($"Browsing: {website}!");
        }

        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
