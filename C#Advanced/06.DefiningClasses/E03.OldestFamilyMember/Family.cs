using System;
using System.Net;

namespace DefiningClasses
{
    public class Family
    {
        //Fields
        private List<Person> families;

        //Constructors
        public Family()
        {
            this.Families = new List<Person>();
        }

        //Properties
        public List<Person> Families { get; set; }

        //Methods
        public void AddMember(Person person)
        {
            Families.Add(person);
        }

        public Person GetOldestMember()
        {
            return Families.MaxBy(x => x.Age);
        }
    }
}
