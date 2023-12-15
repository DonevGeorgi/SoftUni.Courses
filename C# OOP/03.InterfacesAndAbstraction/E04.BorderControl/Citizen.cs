using Е04.BorderControl;

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }
        public string Id
        {
            get => id;
            set => id = value;
        }

    }
}
