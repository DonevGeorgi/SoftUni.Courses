using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;

            Renovators = new List<Renovator>();
        }

        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public List<Renovator> Renovators { get; set; }


        public int Count => Renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
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
                return Renovators.Remove(Renovators.Find(x => x.Name == name));
            }

            return false;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            if (Renovators.Any(x => x.Type == type))
            {
                int count = 0;

                foreach (Renovator renovator in Renovators)
                {
                    if (renovator.Type == type)
                    {
                        count++;
                    }
                }

                Renovators.RemoveAll(x => x.Type == type);

                return count;
            }

            return 0;
        }

        public Renovator HireRenovator(string name)
        {
            if (Renovators.Any(x => x.Name == name))
            {
                foreach (Renovator renovator in Renovators)
                {
                    if (renovator.Name == name)
                    {
                        renovator.Hired = true;
                    }
                }

                return Renovators.Find(x => x.Name == name);
            }

            return null;
        }

        public List<Renovator> PayRenovators(int days)
        {
            return Renovators.FindAll(x => x.Days >= days).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (Renovator renovator in Renovators)
            {
                if (renovator.Hired == false)
                {
                    sb.AppendLine(renovator.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
