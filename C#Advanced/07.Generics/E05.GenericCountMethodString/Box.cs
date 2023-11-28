using System.Text;

namespace P03.GenericCountMethodStrings
{
    public class Box<T> where T : IComparable<T>
    {
        private List<T> values;

        public Box()
        {
            values = new List<T>();
        }

        public void Add(T value)
        {
            values.Add(value);
        }

        public int Count(T givenVlueForComparison)
        {
            int count = 0;

            foreach (var value in values)
            {
                if (value.CompareTo(givenVlueForComparison) > 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
