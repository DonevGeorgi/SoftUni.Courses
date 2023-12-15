using PersonInfo.Models.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo.Models.Classes
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string name, string lastName, decimal salary, IReadOnlyCollection<IPrivate> privates)
            : base(id, name, lastName, salary)
        {
            Privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new($"Name: {Name} {LastName} Id: {Id} Salary: {Salary:f2}");

            sb.AppendLine();

            sb.AppendLine("Privates:");

            foreach (IPrivate currPrivate in Privates)
            {
                sb.AppendLine($"  {currPrivate.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
