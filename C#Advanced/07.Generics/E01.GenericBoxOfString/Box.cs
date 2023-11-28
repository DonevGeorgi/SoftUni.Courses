using System.Text;

namespace BoxOfString
{
    public class Box<T>
    {
        private List<T> value;

        public Box()
        {
            value = new();
        }

        public void Add(T item)
        {
            value.Add(item);
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            foreach (T item in value)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
