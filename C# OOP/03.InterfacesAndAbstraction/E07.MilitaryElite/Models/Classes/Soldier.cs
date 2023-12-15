using PersonInfo.Models.Interfaces;

namespace PersonInfo.Models.Classes
{
    public abstract class Soldier : ISoldier
    {
        public Soldier(int id, string name, string lastName)
        {
            Id = id;
            Name = name;
            LastName = lastName;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string LastName { get; private set; }
    }
}
