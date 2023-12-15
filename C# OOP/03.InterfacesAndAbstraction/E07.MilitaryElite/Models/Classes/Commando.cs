using PersonInfo.Models.Enums;
using PersonInfo.Models.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace PersonInfo.Models.Classes
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string name, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IMission> missions)
            : base(id, name, lastName, salary, corps)
        {
            Missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"Name: {Name} {LastName} Id: {Id} Salary: {Salary:f2}");

            sb.AppendLine($"Corps: {Corps}");

            sb.AppendLine("Missions:");

            foreach (IMission currMission in Missions)
            {
                sb.AppendLine($"  {currMission.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
