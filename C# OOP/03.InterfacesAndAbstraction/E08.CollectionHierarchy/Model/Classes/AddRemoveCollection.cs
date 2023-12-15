using PersonInfo.Models.Interfaces;
using System.Collections.Generic;

namespace PersonInfo.Models.Classes
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private readonly List<string> collection;

        public AddRemoveCollection()
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
            string removedElement = collection[collection.Count - 1];

            if (collection.Count > 0)
            {
                collection.RemoveAt(collection.Count - 1);
            }

            return removedElement;
        }
    }
}
