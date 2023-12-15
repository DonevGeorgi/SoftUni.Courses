using PersonInfo.Models.Enums;
using PersonInfo.Models.Interfaces;

namespace PersonInfo.Models.Classes
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string name, string lastName, decimal salary, Corps corps)
            : base(id, name, lastName, salary)
        {
            Corps = corps;
        }

        public Corps Corps { get; private set; }
    }
}
