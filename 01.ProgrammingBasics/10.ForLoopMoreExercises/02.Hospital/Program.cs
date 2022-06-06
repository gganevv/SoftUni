using System;

namespace _02.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int doctors = 7;
            int treatedPatients = 0;
            int untreatedpatients = 0;

            for (int i = 1; i <= days; i++)
            {
                if (i % 3 == 0 && untreatedpatients > treatedPatients)
                {
                    doctors++;
                }
                int daylypatients = int.Parse(Console.ReadLine());
                if (daylypatients <= doctors)
                {
                    treatedPatients += daylypatients;
                }
                else
                {
                    treatedPatients += doctors;
                    untreatedpatients += (daylypatients - doctors);
                }
                
            }
            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untreatedpatients}.");
        }
    }
}
