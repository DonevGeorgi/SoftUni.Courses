using System.Text;

namespace P03.GenericSwapMethodStrings
{
    public class Box<T>
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

        public void Swap(int firsIndex, int secondIndex)
        {
            (values[firsIndex], values[secondIndex]) = (values[secondIndex], values[firsIndex]);
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            foreach (T value in values)
            {
                sb.AppendLine($"{typeof(T)}: {value}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
