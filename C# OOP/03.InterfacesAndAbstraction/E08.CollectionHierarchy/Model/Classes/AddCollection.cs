using PersonInfo.Models.Interfaces;
using System.Collections.Generic;

namespace PersonInfo.Models.Classes
{
    public class AddCollection : IAddCollection
    {
        private readonly List<string> collection;

        public AddCollection()
        {
            collection = new();
        }

        public int Add(string element)
        {
            collection.Add(element);

            return collection.IndexOf(element);
        }
    }
}
