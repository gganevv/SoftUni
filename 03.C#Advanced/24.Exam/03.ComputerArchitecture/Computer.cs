using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> multiprocessor;
        private string model;
        private int capacity;

        public string Model { get => model; set => model = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public List<CPU> Multiprocessor { get => multiprocessor; set => multiprocessor = value; }

        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public int Count
        {
            get
            {
                return multiprocessor.Count;
            }
        }

        public void Add(CPU cpu)
        {
            if (Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            CPU cpu = Multiprocessor.FirstOrDefault(x => x.Brand == brand);
            if (cpu != default)
            {
                Multiprocessor.Remove(cpu);
                return true;
            }

            return false;
        }

        public CPU MostPowerful()
            => Multiprocessor.OrderByDescending(x => x.Frequency).First();
        public CPU GetCPU(string brand)
        {
            CPU cpu = Multiprocessor.Find(x => x.Brand == brand);
            if (cpu != default)
            {
                return cpu;
            }
            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {model}:");
            foreach (var cpu in Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
