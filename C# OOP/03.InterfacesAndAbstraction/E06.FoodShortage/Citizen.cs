namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable, IIdentifiable, IBuyer
    {
        private string name;
        private int age;
        private string birthdate;
        private string id;
        private int food;

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = 0;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }

        public int Age
        {
            get => age;
            private set => age = value;
        }
        public string Id
        {
            get => id;
            private set => id = value;
        }
        public string Birthdate
        {
            get => birthdate;
            private set => birthdate = value;
        }

        public int Food
        {
            get => food;
            private set => food = value;
        }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
