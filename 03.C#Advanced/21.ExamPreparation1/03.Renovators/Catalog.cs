using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }

        public List<Renovator> Renovators { get; set; }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => Renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Name == null || renovator.Name == string.Empty || renovator.Type == null || renovator.Type == string.Empty)
            {
                return "Invalid renovator's information.";
            }

            if (Count == NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            if (Renovators.Any(x => x.Name == name))
            {
                Renovator renovatorToRemove = Renovators.First(x => x.Name == name);
                Renovators.Remove(renovatorToRemove);
                return true;
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            return Renovators.RemoveAll(x => x.Type == type);
        }

        public Renovator HireRenovator(string name)
        {
            if (!Renovators.Any(x => x.Name == name))
            {
                return null;
            }

            Renovator renovator = Renovators.First(x => x.Name == name);
            renovator.Hired = true;
            return renovator;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> renovatorsList = new List<Renovator>();
            foreach (var renovator in Renovators)
            {
                if (renovator.Days >= days)
                {
                    renovatorsList.Add(renovator);
                }
            }

            return renovatorsList;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var renovator in Renovators)
            {
                if (renovator.Hired == false)
                {
                    sb.AppendLine(renovator.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
