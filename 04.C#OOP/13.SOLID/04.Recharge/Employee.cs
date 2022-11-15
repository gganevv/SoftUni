using System;
namespace Recharge
{
    public class Employee : Worker, IEmployee
    {
        public string ID { get; set; }

        public Employee(string id)
        {
            ID = id;
        }

        public void Sleep()
        {
            Console.WriteLine("Sleeping");
        }
    }
}
