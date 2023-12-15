namespace PersonInfo
{
    public class Robots : IIdentifiable
    {
        private string name;
        private string id;

        public Robots(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }
        public string Id
        {
            get => id;
            private set => id = value;
        }
    }
}
