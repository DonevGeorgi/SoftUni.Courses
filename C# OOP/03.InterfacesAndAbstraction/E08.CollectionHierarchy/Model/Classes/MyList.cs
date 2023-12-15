using PersonInfo.Models.Interfaces;

namespace PersonInfo.Models.Classes
{
    public class MyList : IMyList
    {
        private readonly List<string> collection;

        public MyList()
        {
            collection = new();
        }

        public int Add(string element)
        {
            collection.Insert(0, element);

            return 0;
        }

        public string Remove()
        {
            string removedElement = collection[0];

            if (collection.Count > 0)
            {
                collection.RemoveAt(0);
            }

            return removedElement;
        }

        public int Used() => collection.Count;
    }
}
