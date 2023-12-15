using PersonInfo.Models.Interfaces;

namespace PersonInfo.Models.Classes
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string name, string lastName, decimal salary)
            : base(id, name, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"Name: {Name} {LastName} Id: {Id} Salary: {Salary:f2}";
        }
    }
}
