using PersonInfo.Models.Interfaces;
using System.Text;
using System.Xml.Linq;

namespace PersonInfo.Models.Classes
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string name, string lastName, int codeNumber)
            : base(id, name, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"Name: {Name} {LastName} Id: {Id}");
            sb.AppendLine($"Code Number: {CodeNumber}");

            return sb.ToString().Trim();
        }
    }
}
