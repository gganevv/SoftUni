namespace Telephony
{
    public class StationaryPhone : IPhone
    {
        public void Call(string number)
        {
            System.Console.WriteLine($"Dialing... {number}");
        }
    }
}
