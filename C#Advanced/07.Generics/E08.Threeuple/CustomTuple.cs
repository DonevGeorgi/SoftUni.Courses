namespace Threeuple
{
    public class CustomTuple<T1, T2, T3>
    {
        public CustomTuple(T1 item1, T2 item2, T3 item3)
        {
            Value1 = item1;
            Value2 = item2;
            Value3 = item3;
        }

        public T1 Value1 { get; private set; }
        public T2 Value2 { get; private set; }
        public T3 Value3 { get; private set; }

        public override string ToString()
        {
            return $"{Value1} -> {Value2} -> {Value3}";
        }
    }
}
