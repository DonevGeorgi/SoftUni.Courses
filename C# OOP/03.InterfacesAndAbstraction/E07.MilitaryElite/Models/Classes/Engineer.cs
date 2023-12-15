using PersonInfo.Models.Enums;
using PersonInfo.Models.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.Models.Classes
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string name, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IRepair> repairs)
            : base(id, name, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public IReadOnlyCollection<IRepair> Repairs { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"Name: {Name} {LastName} Id: {Id} Salary: {Salary:f2}");

            sb.AppendLine($"Corps: {Corps}");

            sb.AppendLine("Repairs:");

            foreach (IRepair currRepair in Repairs)
            {
                sb.AppendLine($"  {currRepair.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
